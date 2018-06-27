﻿using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Manager.Data;
using Manager.Web.AutofacModules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Manager.Web
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
            var connectionString = Configuration.GetConnectionString("ManagerDatabase");

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<GenericContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<GroupBuyingContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddDbContext<SystemContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new DataModule());
            containerBuilder.RegisterModule(new CommandsModule(Configuration["Jwt:Key"], Configuration["Jwt:Issuer"]));
            containerBuilder.RegisterModule(new QueriesModule(connectionString));
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

            app.UseMvc();
        }
    }
}