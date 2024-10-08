using DatabaseModel.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Implementations;
using ScanBoxWebApi.Repository;
using System.Text;

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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });

            builder.Services.AddAuthorization();

            //проверить строку подключения и миграции
            builder.Services.AddDbContext<ScanBoxDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("ScanBoxDb"));
            });

            builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
            builder.Services.AddScoped<ICounterpartyRepository, CounterpartyRepository>();
            builder.Services.AddScoped<ICounterpartyTypeRepository, CounterpartyTypeRepository>();
            builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
            builder.Services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
            builder.Services.AddScoped<IIndividualRepositoty, IndividualRepositoty>();
            builder.Services.AddScoped<IJobTitelRepository, JobTitelRepository>();
            builder.Services.AddScoped<ILegalEntityRepository, LegalEntityRepository>();
            builder.Services.AddScoped<ILegalFormRepository, LegalFormRepository>();
            builder.Services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
            builder.Services.AddScoped<IMovementHistoryRepository, MovementHistoryRepository>();
            builder.Services.AddScoped<IPricesRepository, PricesRepository>();
            builder.Services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            builder.Services.AddScoped<IProductTypeRepository, ProductTypeRepository>();
            builder.Services.AddScoped<IProductUnitRepository, ProductUnitRepository>();
            builder.Services.AddScoped<IShipmentRepository, ShipmentRepository>();
            builder.Services.AddScoped<ISupplierRepository, SupplierRepository>();
            builder.Services.AddScoped<IWarehouseEmployeeRepository, WarehouseEmployeeRepository>();

            builder.Services.AddTransient<IUserService, UserService>();
            builder.Services.AddTransient<ITokenGenerator, TokenGenerator>();

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
