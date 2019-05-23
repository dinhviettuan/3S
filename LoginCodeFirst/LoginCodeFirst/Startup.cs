using System;
using System.Collections.Generic;
using System.Globalization;
using AutoMapper;
using FluentValidation.AspNetCore;
using LoginCodeFirst.Filter;
using LoginCodeFirst.Models;
using LoginCodeFirst.Resources;
using LoginCodeFirst.Services;
using LoginCodeFirst.Validators.User;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace LoginCodeFirst
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
            
            services.AddAutoMapper();
//           
            services.AddSession();
            services.AddSingleton<ResourcesServices<BrandResources>>();
            services.AddSingleton<ResourcesServices<CommonResources>>();
            services.AddSingleton<ResourcesServices<CategoryResources>>();
            services.AddSingleton<ResourcesServices<LoginResources>>();
            services.AddSingleton<ResourcesServices<ProductResources>>();
            services.AddSingleton<ResourcesServices<StockResources>>();
            services.AddSingleton<ResourcesServices<StoreResources>>();
            services.AddSingleton<ResourcesServices<UserResources>>();
            #region snippet1
            
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = new PathString("/Error/401");
                    options.LoginPath = new PathString("/Login/Login");
                    options.ReturnUrlParameter = "RequestPath";
                    options.SlidingExpiration = true;
                    options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                });
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new List<CultureInfo>
                {

                    new CultureInfo("en-US"),
                    new CultureInfo("vi-VN")
                };
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
            });

            #endregion

            
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<ICategoryServices, CategoryServices>();
            services.AddTransient<IBrandServices, BrandServices>();
            services.AddTransient<IProductServices, ProductServices>();
            services.AddTransient<IStockServices, StockServices>();
            services.AddTransient<IStoreServices, StoreServices>(); 
            services.AddScoped<ActionFilter>();

            services.AddDbContext<CodeDataContext>(item => item.UseSqlServer(Configuration.GetConnectionString("connectdb")));
            services.AddMvc()
                .AddViewLocalization(opts => { opts.ResourcesPath = "Resources";})
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization()
                .AddViewLocalization()
                .AddDataAnnotationsLocalization()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2).AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>());

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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();
            app.Use(async (context, next) =>
            {
                await next();
                if (!context.Response.HasStarted && context.Response.StatusCode != StatusCodes.Status200OK)
                {
                    switch (context.Response.StatusCode)
                    {
                        case StatusCodes.Status400BadRequest:
                            context.Request.Path ="/Error/400";
                            await next();
                            break;
                        case StatusCodes.Status401Unauthorized:
                            context.Request.Path ="/Error/401";
                            await next();
                            break;
                    }
                }
            });
            #region snippet2
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            app.UseAuthentication();
            #endregion
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}