using CatalogApi.Dtos;
using CatalogApi.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                var categoryService = serviceProvider.GetRequiredService<ICategoryService>();

                if (!categoryService.GetAllAsync().Result.Data.Any())
                {
                    categoryService.CreateAsync(new CategoryDto { Name = "Elektronik" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Giyim" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Ev Aletleri" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Spor Aletleri" }).Wait();
                    categoryService.CreateAsync(new CategoryDto { Name = "Hırdavat" }).Wait();
                }
            }

            host.Run();


        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
