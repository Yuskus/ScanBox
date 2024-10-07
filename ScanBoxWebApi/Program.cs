using DatabaseModel.Context;
using Microsoft.EntityFrameworkCore;
using ScanBoxWebApi.Abstractions;
using ScanBoxWebApi.Repository;

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
            builder.Services.AddSwaggerGen();

            //раскомментировать

            /*builder.Services.AddScoped<IBuyerRepository, BuyerRepository>();
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
            builder.Services.AddScoped<IWarehouseEmployeeRepository, WarehouseEmployeeRepository>();*/

            //проверить строку подключения и миграции
            builder.Services.AddDbContext<ScanBoxDbContext>(options =>
            {
                options.UseLazyLoadingProxies().UseNpgsql(builder.Configuration.GetConnectionString("ScanBoxDb"));
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            //app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
