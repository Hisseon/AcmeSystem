using AcmeSys.Infra.EntityFrmwk;
using Microsoft.EntityFrameworkCore;
using AcmeSys.Dominio.Interfaces;
using AcmeSys.Infra.Repositories;
using AcmeSys.App.Services;

namespace AcmeSystem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddHttpClient();
            services.AddControllers(); 
            services.AddRazorPages();
            services.AddScoped<ProductService>();
            services.AddScoped<InventoryService>();
            services.AddScoped<SaleService>();
            services.AddScoped<PurchaseService>();  
            services.AddScoped<SubsidiaryService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISubsidiaryRepository, SubsidiaryRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<ISaleRepository, SaleRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers(); 
            });
        }
    }

}
