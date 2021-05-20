using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AuthServer.Infrastructure.Data.Identity;
using AuthServer.Data;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using AuthServer;
using IdentityServer4.Services;
using AuthServer.Services;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

using AuthServer.Extensions;
using ProjectEngine.IdentityServer.services;
using Microsoft.AspNetCore.Identity.UI.Services;
using ProjectEngine.IdentityServer.Models;

namespace ProjectEngine.IdentityServer
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
            /*services.AddDbContext<ApplicationDbContext>(options =>
                options.AddEntityFrameworkNpgsql(
                    Configuration.GetConnectionString("DefaultConnection")));
            */
            services.AddEntityFrameworkNpgsql().
                 AddDbContext<AppIdentityDbContext>(
                opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"))
             );

            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                
                options.SignIn.RequireConfirmedEmail = true;
            })
               .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            var appSetting = Configuration.GetSection("AppSetting");
            services.Configure<AppSetting>(appSetting);

            var appSettings = appSetting.Get<AppSetting>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
/*
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })

             .AddJwtBearer(x =>
             {
                 x.RequireHttpsMetadata = false;
                 x.SaveToken = true;
                 x.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuerSigningKey = true,
                     IssuerSigningKey = new SymmetricSecurityKey(key),
                     ValidateIssuer = false,
                     ValidateAudience = false

                 };

             });
            */
            services.AddIdentityServer()
               .AddDeveloperSigningCredential()
               // this adds the operational data from DB (codes, tokens, consents)
               .AddOperationalStore(options =>
               {
                   options.ConfigureDbContext = builder => builder.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));
                    // this enables automatic token cleanup. this is optional.
                    options.EnableTokenCleanup = true;
                   options.TokenCleanupInterval = 30; // interval in seconds

                })
               //.AddInMemoryPersistedGrants()
               .AddInMemoryIdentityResources(Config.GetIdentityResources())
               .AddInMemoryApiResources(Config.GetApiResources())
               .AddInMemoryClients(Config.GetClients())
               .AddAspNetIdentity<AppUser>();

            services.AddTransient<IProfileService, IdentityClaimsProfileService>();

            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()));

            services.AddControllersWithViews();

            services.AddTransient<IEmailSender, EmailSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration.GetSection("AuthMessageSenderOptions"));
            services.AddRazorPages();

            //services.AddTransient<DataSeed>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

         /*   if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
*/
            app.UseExceptionHandler(builder =>
            {
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.Headers.Add("Access-Control-Allow-Origin", "*");

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        context.Response.AddApplicationError(error.Error.Message);
                        await context.Response.WriteAsync(error.Error.Message).ConfigureAwait(false);
                    }
                });
            });
            //app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseCors("AllowAll");
            app.UseIdentityServer();

            /*app.UseAuthentication();
            app.UseAuthorization();*/

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            //DataSeed.SeedData(userManager);



        }
    }
}
