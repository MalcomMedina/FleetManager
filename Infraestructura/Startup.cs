using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Dominio.DataAccess.DBContexts;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Dominio.Helpers.Attributes;
using Dominio.Helpers.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infraestructura
{
    public class Startup
    {
        public Startup(IConfiguration Configuration)
        {
            configuration = Configuration;
        }

        public IConfiguration configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //configure AuthorizeActionFilter
            services.AddScoped<AuthorizeActionFilter>();
            //configure filters in mvc 

            //services.AddMvc(options => 
            //{
            //    options.Filters.Add(typeof(ExceptionOnActionFilter)); 
            //});

            //configure services of automapper
            services.AddAutoMapper(configuration => configuration.AddProfile<AutoMapperProfiles>(), 
                                                    typeof(Startup));
            //get connection string from AppSettings.json
            services.AddDbContext<FleetManagerContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("FleetManager")));

            //configure scheme autentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(configuration["JWT:key"])
                        ),  ClockSkew = TimeSpan.Zero
                    };
                });

            //add scoped to use IStrategyAdaptableContext in classes
            //services.AddScoped<IStrategyAdaptableContext, FleetManagerContext>();
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
