using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZZG.Business.Abstract;
using ZZG.Business.Concrete;
using ZZG.DataAccess.Abstract;
using ZZG.DataAccess.Concrete.EfCore;
using ZZG.WebUI.Middlewares;

namespace ZZG.WebUI
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
            services.AddScoped<IProductDal, ProductDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<ICategoryService, CategoryManager>();


            services.AddControllersWithViews();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                SeedDatabase.Seed();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            //app.CustomStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllerRoute(
              name: "adminCategory",
              pattern: "admin/categories",
              defaults: new { controller = "Admin", action = "CategoryList" }
             );
               endpoints.MapControllerRoute(
               name: "adminCategory",
               pattern: "admin/categories/{*id}",
               defaults: new { controller = "Admin", action = "EditCategory" }
              );
               endpoints.MapControllerRoute(
               name: "adminProducts",
               pattern: "admin/products",
               defaults: new { controller = "Admin", action = "ProductList" }
              );
               endpoints.MapControllerRoute(
               name: "adminProducts",
               pattern: "admin/products/{*id}",
               defaults: new { controller = "Admin", action = "EditProduct" }
              );
               endpoints.MapControllerRoute(
               name: "products",
               pattern: "products/{*category}",
               defaults: new { controller = "Shop", action = "List" }
               );
               endpoints.MapControllerRoute(
               name: "default",
               pattern: "{controller}/{action}/{id?}",
               defaults: new { controller = "Home", action = "Index" }
               );
           });
        }
    }
}
