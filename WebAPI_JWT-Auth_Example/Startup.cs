using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebAPI_JWT_Auth_Example.Data;
using WebAPI_JWT_Auth_Example.Extensions;
using WebAPI_JWT_Auth_Example.Helpers;
using WebAPI_JWT_Auth_Example.Models;

namespace WebAPI_JWT_Auth_Example
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            // use in-memory database
            services.AddDbContext<ApplicationContext>(options => options.UseInMemoryDatabase("AppTestDb"));

            // use identity for users
            services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationContext>();

            services.AddCors();
            services.AddControllers();

            // extension for register services
            services.AddServices();

            // configure strongly typed settings objects
            var jwtAppSettingSection = Configuration.GetSection("JwtSettings");
            services.Configure<AppSettings>(jwtAppSettingSection);
            var jwtAppTokenSettings = jwtAppSettingSection.Get<AppSettings>();
            var key = Encoding.UTF8.GetBytes(jwtAppTokenSettings.Key);

            // jwt auth configs
            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtAppTokenSettings.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwtAppTokenSettings.Audience,

                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),

                        ClockSkew = TimeSpan.Zero
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
