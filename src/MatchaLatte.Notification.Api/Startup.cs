using System.IdentityModel.Tokens.Jwt;
using Autofac;
using MatchaLatte.Notification.Api.AutofacModules;
using MatchaLatte.Notification.Api.Extensions;
using MatchaLatte.Notification.Api.Hubs;
using MatchaLatte.Notification.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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