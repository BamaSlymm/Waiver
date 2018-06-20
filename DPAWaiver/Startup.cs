using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Data;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DPAWaiver
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
            services.AddSingleton<ILOVService, LOVService>();
            services.AddMvc();
            ConfigureEntityFramework(services);
        }

        public void ConfigureEntityFramework(IServiceCollection services)
        {
            Console.WriteLine("DB Connection: {0}", Configuration.GetConnectionString("DefaultConnection"));
            var configurationSections = Configuration.GetChildren();
            foreach (var section in configurationSections)
            {
                foreach(var env in section.GetChildren())
                {
                    Console.WriteLine($"{env.Key}:{ env.Value}");
                }
            }
            services.AddDbContext<WaiverDBContext>(
                options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    mysqlOptions =>
                    {
                        mysqlOptions.MaxBatchSize(AppConfig.EfBatchSize);
                        if (AppConfig.EfRetryOnFailure > 0)
                            mysqlOptions.EnableRetryOnFailure(AppConfig.EfRetryOnFailure, TimeSpan.FromSeconds(5), null);
                    }
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
