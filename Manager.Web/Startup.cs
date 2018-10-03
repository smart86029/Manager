using System;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Manager.Data;
using Manager.Web.AutofacModules;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

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

            services.AddMvc(options =>
            {
                options.Filters.Add(new ProducesAttribute("application/json"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    ValidAudience = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });
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
            containerBuilder.RegisterModule(new EventBusModule(Configuration["EventBus:Connection"], Configuration["EventBus:UserName"],
                Configuration["EventBus:Password"], Convert.ToInt32(Configuration["EventBus:RetryCount"])));
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

            app.UseAuthentication();
            app.UseMvc();
        }
    }
}