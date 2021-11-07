using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Repository;

namespace Shop
{
    public class Startup
    {
        //Нужно для получения json файла в котором хранится инфа о подключении к базе данных
        private IConfigurationRoot _confString;
        public Startup(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostEnv)
        {
            _confString = new ConfigurationBuilder().SetBasePath(hostEnv.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        } 

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) // для регистрации различных модулей и плагинов
        {
            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_confString.GetConnectionString("DefaultConnection")));
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddTransient<IAllCars, CarRepository>(); //связывает интерфес и класс реализующий его
            services.AddTransient<ICarsCategory, CategoryRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            //вылетел эксепшн после запуска
            app.UseMvcWithDefaultRoute();//если в url не указываем полный путь к файлу, который надо отобразить, тогда отображаем дефолтный пейдж

            using (var scope = app.ApplicationServices.CreateScope()) //нужно создать внутреннее окружение из-за того, что AppDBContent в стартапе подключен как сервис, поэтому здесь тоже делаем сервис
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }
            
        }
    }
}
