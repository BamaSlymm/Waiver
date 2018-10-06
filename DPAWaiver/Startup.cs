using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using DPAWaiver.Areas.Identity.Data;
using DPAWaiver.Models;
using DPAWaiver.Razor;
using DPAWaiver.Security;
using DPAWaiver.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
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
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
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
            services.AddAuthorization(options=> {
                options.AddPolicy("RequireReviewerRole",policy => policy.RequireRole(GroupNames.Reviewer));
            });
            services.AddMvc().
                AddRazorPagesOptions(options =>
                    {
                        options.Conventions.AuthorizeFolder("/Private");
                        options.Conventions.AuthorizeFolder("/Private/Review","RequireReviewerRole");
                    })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureEntityFramework(services);

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 12;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
                options.Password.RequiredUniqueChars = 6;

                // Lockout settings
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                options.Lockout.MaxFailedAccessAttempts = 10;
                options.Lockout.AllowedForNewUsers = false;

                // User settings
                options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                // If the LoginPath isn't set, ASP.NET Core defaults 
                // the path to /Account/Login.
                options.LoginPath = "/Account/Login";
                // If the AccessDeniedPath isn't set, ASP.NET Core defaults 
                // the path to /Account/AccessDenied.
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });


            services.AddSingleton<IEmailSender, EmailSender>();
            services.AddSingleton<IStorageUtil, StorageUtil>();
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("Email"));
            services.Configure<GoogleReCaptchaOptions>(Configuration.GetSection("GoogleReCaptcha"));
            services.Configure<GoogleCloudStorageOptions>(Configuration.GetSection("GoogleCloudStorage"));
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

            services.AddIdentity<DPAUser, DPARole>()
                    .AddEntityFrameworkStores<DPAWaiverIdentityDbContext>()
                    .AddDefaultTokenProviders()
                    .AddDefaultUI();
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
                var options = new RewriteOptions().
                Add(new RewriteHttpsOnAppEngine(HttpsPolicy.Required));
                app.UseRewriter(options);
            }
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc();
        }
    }

}
