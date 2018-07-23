using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddTransient<ILOVService, LOVService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureEntityFramework(services);
        }

        private void ConfigureEntityFramework(IServiceCollection services)
        {
            Console.WriteLine("DB Connection: {0}", Configuration.GetConnectionString("DefaultConnection"));
            var configurationSections = Configuration.GetChildren();
            foreach (var section in configurationSections)
            {
                foreach (var env in section.GetChildren())
                {
                    Console.WriteLine($"{env.Key}:{ env.Value}");
                }
            }

            services.AddDbContext<DPAWaiverIdentityDbContext>(
                options => options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                 mysqlOptions =>
                 {
                     mysqlOptions.MaxBatchSize(AppConfig.EfBatchSize);
                     if (AppConfig.EfRetryOnFailure > 0)
                         mysqlOptions.EnableRetryOnFailure(AppConfig.EfRetryOnFailure, TimeSpan.FromSeconds(5), null);
                 }));

            services.AddDefaultIdentity<DPAUser>()
                    .AddEntityFrameworkStores<DPAWaiverIdentityDbContext>();
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
                // app.UseHsts();
            }

            // app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
