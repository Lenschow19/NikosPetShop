using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.IdentityModel.Tokens;
using NikosPetShop.Core.ApplicationServices;
using NikosPetShop.Core.ApplicationServices.Impl;
using NikosPetShop.Core.DomainServices;
using NikosPetShop.Infrastructure.DBInitialization;
using NikosPetShop.Infrastructure.SQLite.Data;
using NikosPetShop.InfraStructure.Data;
using NikosPetShop.InfraStructure.Data.Repositories;
using NikosPetShop.Infrastructure.Security;

namespace NikosPetShop.WebAPI
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
            // Create a byte array with random values. This byte array is used
            // to generate a key for signing JWT tokens.
            Byte[] secretBytes = new byte[40];
            Random rand = new Random();
            rand.NextBytes(secretBytes);

            services.AddScoped<IPetRepository, PetRepository>();
            services.AddScoped<IPetService, PetService>();
            services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddSingleton<IPetTypeRepository, PetTypeRepository>();
            services.AddScoped<IPetTypeService, PetTypeService>();
            services.AddScoped<DBInitializer>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserSQLRepository>();
            services.AddSingleton<IAuthenticationHelper>(new AuthenticationHelper(secretBytes));
            services.AddControllers();

            services.AddCors(options => options.AddDefaultPolicy
                            (builder => { builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }
                            ));

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.MaxDepth = 3;
            });

            services.AddDbContext<NikosPetShopLiteContext>(opt => { opt.UseSqlite("Data Source=NikosPetShopApp.db"); }, ServiceLifetime.Transient);


            // Add JWT based authentication
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    //ValidAudience = "TodoApiClient",
                    ValidateIssuer = false,
                    //ValidIssuer = "TodoApi",
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretBytes),
                    ValidateLifetime = true, //validate the expiration and not before values in the token
                    ClockSkew = TimeSpan.FromMinutes(5) //5 minute tolerance for the expiration date
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using(var scope = app.ApplicationServices.CreateScope())
            {
               
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<NikosPetShopLiteContext>();
                    ctx.Database.EnsureDeleted();
                    ctx.Database.EnsureCreated();

                    DBInitializer dataInitilizer = scope.ServiceProvider.GetRequiredService<DBInitializer>();
                    dataInitilizer.InitData();
                }
            }

            app.UseCors();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }
    }
}
