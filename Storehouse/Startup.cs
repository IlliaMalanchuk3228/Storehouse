using DAL.DataContexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BLL.Iml;
using BLL.Interfaces;
using DAL.Repositories;

namespace Storehouse
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Storehouse", Version = "v1"});
            });

            services.AddDbContext<DataContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"), 
                    assembly => assembly.MigrationsAssembly("Storehouse")));
            // add depenciiii
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>)); 
            services.AddTransient<IProductRepository, ProductRepository>(); 
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IBuyQueueRepository, BuyQueueRepository>();
            services.AddTransient<ITransportQueueRepository, TransportQueueRepository>();

            
            services.AddScoped<IProductManager, ProductManager>();
            services.AddScoped<IBuyQueueManager, BuyQueueManager>();
            services.AddScoped<ITransportQueueManager, TransportQueueManager>();
            services.AddScoped<IOrderManager, OrderManager>();
            services.AddScoped<ICustomerManager, CustomerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Storehouse v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}