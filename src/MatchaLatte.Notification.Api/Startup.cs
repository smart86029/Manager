using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MatchaLatte.Notification.Api.AutofacModules;
using MatchaLatte.Notification.Api.Hubs;
using MatchaLatte.Notification.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MatchaLatte.Notification.Api
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddSignalR();
            services.Configure<MongoSettings>(Configuration.GetSection("Mongo"));

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataModule(Configuration["Mongo:ConnectionString"], Configuration["Mongo:DatabaseName"]));
            containerBuilder.RegisterModule(new ServicesModule());
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSignalR(routes => routes.MapHub<ChatHub>("/hub", options => options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransports.All));
            app.UseMvc();
        }
    }
}