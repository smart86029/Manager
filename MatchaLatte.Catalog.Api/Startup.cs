using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MatchaLatte.Catalog.Api.AutofacModules;
using MatchaLatte.Catalog.Api.Extensions;
using MatchaLatte.Catalog.Api.Models;
using MatchaLatte.Catalog.Data;
using MatchaLatte.Catalog.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MatchaLatte.Catalog.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("sub");

            services.Configure<PictureSettings>(Configuration.GetSection("Picture"));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<CatalogContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Catalog"));
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<CurrentUser, CurrentUser>();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AppModule());
            containerBuilder.RegisterModule(new CommonModule(Configuration.GetConnectionString("EventBus")));
            containerBuilder.RegisterModule(new DataModule());
            containerBuilder.RegisterModule(new ServicesModule());
            containerBuilder.Register(c => c.Resolve<IOptions<PictureSettings>>().Value);
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();

            return new AutofacServiceProvider(container);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseEventBus();
        }
    }
}