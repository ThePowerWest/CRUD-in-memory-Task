using ApplicationCore.Interfaces.Base;
using ApplicationCore.Services;
using Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.Interfaces;

namespace App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configuration IoC (DI)
        /// </summary>
        /// <param name="services">Specifies the contract for a collection of service descriptors.</param>
        private static void ConfigureDI(IServiceCollection services)
        {
            services.AddScoped(typeof(IEFRepository<>), typeof(EFRepository<>));
            services.AddScoped<IWorkerService, WorkerService>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MainContext>(option => option.UseInMemoryDatabase(Configuration.GetConnectionString("MyDb")));
            
            ConfigureDI(services);

            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var scopedProvider = scope.ServiceProvider;
                try
                {
                    var mainContext = scopedProvider.GetRequiredService<MainContext>();
                    MainContextSeed.SeedAsync(mainContext).GetAwaiter();

                }
                catch { }
            }
        }
    }
}