using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Implementations;
using ScanBoxWebApi.Mapper;
using ScanBoxWebApi.Repository;
using ScanBoxWebApi.Utilities;

namespace ScanBoxWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "ScanBox Web API"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                 {
                     Name = "Authorization",
                     Type = SecuritySchemeType.ApiKey,
                     Scheme = "Bearer",
                     BearerFormat = "JWT",
                     In = ParameterLocation.Header,
                     Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                 });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            []
                    }
                });
            });

            // для аутентификации и авторизации
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new RsaSecurityKey(RSATool.GetKey("public_key.pem"))
                };
            });

            // контекст бд (проверить строку подключения и миграции)
            builder.Services.AddScoped(x => new ScanBoxDbContext(builder.Configuration.GetConnectionString("ScanBoxDb")!));

            // маппинг
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // для работы с бд
            builder.Services.AddScoped<ICrudMethodRepository<BuyerGetDTO, BuyerPostDTO>, BuyerRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<CounterpartyGetDTO, CounterpartyPostDTO>, CounterpartyRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<CounterpartyTypeGetDTO, CounterpartyTypePostDTO>, CounterpartyTypeRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<DocumentGetDTO, DocumentPostDTO>, DocumentRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<DocumentTypeGetDTO, DocumentTypePostDTO>, DocumentTypeRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<IndividualGetDTO, IndividualPostDTO>, IndividualRepositoty>();
            builder.Services.AddScoped<ICrudMethodRepository<JobTitleGetDTO, JobTitlePostDTO>, JobTitelRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<LegalEntityGetDTO, LegalEntityPostDTO>, LegalEntityRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<LegalFormGetDTO, LegalFormPostDTO>, LegalFormRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<ManufacturerGetDTO, ManufacturerPostDTO>, ManufacturerRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<MovementHistoryGetDTO, MovementHistoryPostDTO>, MovementHistoryRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<PricesGetDTO, PricesPostDTO>, PricesRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<ProductCategoryGetDTO, ProductCategoryPostDTO>, ProductCategoryRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<ProductTypeGetDTO, ProductTypePostDTO>, ProductTypeRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<ProductUnitGetDTO, ProductUnitPostDTO>, ProductUnitRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<ShipmentGetDTO, ShipmentPostDTO>, ShipmentRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<SupplierGetDTO, SupplierPostDTO>, SupplierRepository>();
            builder.Services.AddScoped<ICrudMethodRepository<WarehouseEmployeeGetDTO, WarehouseEmployeePostDTO>, WarehouseEmployeeRepository>();

            // для регистрации, аутентификации и авторизации
            builder.Services.AddTransient<IRegister, Register>();
            builder.Services.AddTransient<IUserRightsService, UserService>();
            builder.Services.AddTransient<ITokenGenerator, TokenGenerator>();
            
            // прочие имплементации
            builder.Services.AddTransient<IShipmentComparer<ShipmentGetDTO>, ShipmentComparer>();
            builder.Services.AddTransient<ITableConverter<T>, TableToCsvConverter<T>>();

            // добавление логирования
            builder.Logging.AddConsole();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
