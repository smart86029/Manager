using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using MatchaLatte.Notification.Api.AutofacModules;
using MatchaLatte.Notification.Api.Extensions;
using MatchaLatte.Notification.Api.Hubs;
using MatchaLatte.Notification.Api.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace MatchaLatte.Notification.Api
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove(JwtRegisteredClaimNames.Sub);

            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
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
                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/hub")) 
                                context.Token = accessToken;

                            return Task.CompletedTask;
                        }
                    };
                });

            services.AddSignalR();
            services.Configure<MongoSettings>(Configuration.GetSection("Mongo"));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new CommonModule(Configuration.GetConnectionString("EventBus")));
            builder.RegisterModule(new DataModule(Configuration["Mongo:ConnectionString"], Configuration["Mongo:DatabaseName"]));
            builder.RegisterModule(new EventsModule());
            builder.RegisterModule(new ServicesModule());
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseEventBus();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<ChatHub>("/hub");
            });
        }
    }
}