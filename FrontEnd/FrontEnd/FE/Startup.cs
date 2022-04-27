using FE.Servicios;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FE
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
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", Config =>
            {
                Config.Cookie.Name = "Grandmas.cookie";
                Config.LoginPath = "/Login/Login";
            });
            services.AddSession();
            services.AddMvc(option => option.EnableEndpointRouting = false);

            services.AddControllersWithViews();

            services.AddScoped<IClienteServicio, ClienteServicio>();
            services.AddScoped<IDistribuidorServicio, DistribuidorServicio>();
            services.AddScoped<IEmpleadoServicio, EmpleadoSerivicio>();
            services.AddScoped<IProductoServicio, ProductoServicio>();
            services.AddScoped<IRegistroFacturaServicio, RegistroFacturaServicio>();
            services.AddScoped<IRolEmpleadoServicio, RolEmpleadoServicio>();
            services.AddScoped<IVinculoProductoServicio, VinculoProductoServicio>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSession();

            app.UseMvc(router =>

            {

                router.MapRoute(

                name: "default",

                template: "{controller=Login}/{action=Login}/{id?}");

            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Productos}/{action=Index}/{id?}");
            });
        }
    }
}
