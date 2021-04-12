using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ProductCatalogAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductCatalogAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //here we split up the .Build.Run so that the database is seeded
            //before it is available to the user
            var host = CreateHostBuilder(args).Build();
            

            using (var scope = host.Services.CreateScope())
            {
                var serviceProviders = scope.ServiceProvider;
                var context = serviceProviders.GetRequiredService<EventContext>();
                EventSeed.Seed(context);
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
