using DatabaseModel.Context;
using ScanBoxWebApi.DTO.GetDTO;
using ScanBoxWebApi.DTO.PostDTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

            builder.Configuration.AddJsonFile("appsettings.json")
                                 .AddEnvironmentVariables();

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
                    IssuerSigningKey = new RsaSecurityKey(RSATool.GetPublicKey())
                };
            });

            // контекст бд (проверить строку подключения и миграции)
            string connectionString = builder.Configuration["DB_CONNECTION_STRING"] ?? throw new Exception("Warning! Connection string was not found!");
            builder.Services.AddScoped(x => new ScanBoxDbContext(connectionString));

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
            builder.Services.AddTransient<IShipmentComparer, ShipmentComparer>();
            builder.Services.AddTransient<ITableConverter<BuyerGetDTO>, TableToCsvConverter<BuyerGetDTO>>();
            builder.Services.AddTransient<ITableConverter<CounterpartyGetDTO>, TableToCsvConverter<CounterpartyGetDTO>>();
            builder.Services.AddTransient<ITableConverter<CounterpartyTypeGetDTO>, TableToCsvConverter<CounterpartyTypeGetDTO>>();
            builder.Services.AddTransient<ITableConverter<DocumentGetDTO>, TableToCsvConverter<DocumentGetDTO>>();
            builder.Services.AddTransient<ITableConverter<DocumentTypeGetDTO>, TableToCsvConverter<DocumentTypeGetDTO>>();
            builder.Services.AddTransient<ITableConverter<IndividualGetDTO>, TableToCsvConverter<IndividualGetDTO>>();
            builder.Services.AddTransient<ITableConverter<JobTitleGetDTO>, TableToCsvConverter<JobTitleGetDTO>>();
            builder.Services.AddTransient<ITableConverter<LegalEntityGetDTO>, TableToCsvConverter<LegalEntityGetDTO>>();
            builder.Services.AddTransient<ITableConverter<LegalFormGetDTO>, TableToCsvConverter<LegalFormGetDTO>>();
            builder.Services.AddTransient<ITableConverter<ManufacturerGetDTO>, TableToCsvConverter<ManufacturerGetDTO>>();
            builder.Services.AddTransient<ITableConverter<MovementHistoryGetDTO>, TableToCsvConverter<MovementHistoryGetDTO>>();
            builder.Services.AddTransient<ITableConverter<PricesGetDTO>, TableToCsvConverter<PricesGetDTO>>();
            builder.Services.AddTransient<ITableConverter<ProductCategoryGetDTO>, TableToCsvConverter<ProductCategoryGetDTO>>();
            builder.Services.AddTransient<ITableConverter<ProductTypeGetDTO>, TableToCsvConverter<ProductTypeGetDTO>>();
            builder.Services.AddTransient<ITableConverter<ProductUnitGetDTO>, TableToCsvConverter<ProductUnitGetDTO>>();
            builder.Services.AddTransient<ITableConverter<ShipmentGetDTO>, TableToCsvConverter<ShipmentGetDTO>>();
            builder.Services.AddTransient<ITableConverter<SupplierGetDTO>, TableToCsvConverter<SupplierGetDTO>>();
            builder.Services.AddTransient<ITableConverter<WarehouseEmployeeGetDTO>, TableToCsvConverter<WarehouseEmployeeGetDTO>>();

            // добавление логирования
            builder.Logging.AddConsole();

            // добавление кэширования
            builder.Services.AddMemoryCache(x => x.TrackStatistics = true);

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
