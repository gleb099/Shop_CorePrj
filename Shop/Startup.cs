using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // для регистрации различных модулей и плагинов
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            //MvcOptions.EnableEndpointRouting = false;
            services.AddTransient<IAllCars, MockCars>(); //связывает интерфес и класс реализующий его
            services.AddTransient<ICarsCategory, MockCategory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //вылетел эксепшн после запуска
            app.UseMvcWithDefaultRoute();//если в url не указываем полный путь к файлу, который надо отобразить, тогда отображаем дефолтный пейдж
        }
    }
}
