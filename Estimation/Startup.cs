using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Estimation.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using ProjectEngine.Application;
using FluentValidation.AspNetCore;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace Estimation
{
    public class Startup
    {
        string _connectionString = null;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
             _connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddPersistence(Configuration);
            services.AddApplication();

            /*  services.ConfigureCors();
             services.ConfigureIISIntegration();

             services.AddEntityFrameworkNpgsql().

                 AddDbContext<RepositoryContext>(
                 opt => opt.UseNpgsql(_connectionString)
              );

             services.AddIdentity<ApplicationUser, IdentityRole>(options =>
             {
                 options.Password.RequireDigit = false;
                 options.Password.RequiredLength = 4;
                 options.Password.RequireNonAlphanumeric = false;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireLowercase = false;
             })
                 .AddEntityFrameworkStores<RepositoryContext>()
                  .AddDefaultTokenProviders();



             services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
             services.AddScoped<IUserRepository, UserRepository>();
             services.AddScoped<IEstimationProjectRepository, EstimationProjectRepository>();

             var appSetting = Configuration.GetSection("AppSetting");
             services.Configure<AppSetting>(appSetting);

             var appSettings = appSetting.Get<AppSetting>();
             var key = Encoding.ASCII.GetBytes(appSettings.Secret);

             JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

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

             services.AddControllers();


             services.AddTransient<DataSeed>();

             */
        /*
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
            services.AddScoped<IEstimationProjectRepository, EstimationProjectRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddEntityFrameworkNpgsql().

                 AddDbContext<RepositoryContext>(
                 opt => opt.UseNpgsql(_connectionString)
              );
        */
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:5000";
                o.Audience = "resourceapi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            });

            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            })
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RepositoryContext>())
                 .AddNewtonsoftJson(options => {
                    // options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                 })
                .SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddControllers();

            services.AddTransient<DataSeed>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataSeed dataSeed)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            //app.UseCors("CorsPolicy");
            app.UseCors(options => options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                      name: "default",
                      pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        
            if(dataSeed != null)
            {
                dataSeed.SeedData();
            }
            

          
        }
    }
}
