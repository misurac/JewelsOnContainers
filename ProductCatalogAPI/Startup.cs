using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            //creating a variable and setting it to the json value of ConnectionString
            //var connectionString = Configuration["ConnectionString"];
            //injecting the connection string to dbcontext
            //telling the program what kind of database you will use

            var DatabaseServer = Configuration["DatabaseServer"];
            var DatabaseName = Configuration["DatabaseName"];
            var DatabaseUser = Configuration["DatabaseUser"];
            var DatabasePassword = Configuration["DatabasePassword"];
            var connectionString = $"Server={DatabaseServer};Database={DatabaseName};Trusted_Connection=False;User Id={DatabaseUser};Password={DatabasePassword}";

            services.AddDbContext<EventContext>(options => options.UseSqlServer(connectionString));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
