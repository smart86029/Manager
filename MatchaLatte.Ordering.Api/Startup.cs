using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Text;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MatchaLatte.Common.Events;
using MatchaLatte.Common.Exceptions;
using MatchaLatte.Ordering.Api.AutofacModules;
using MatchaLatte.Ordering.Api.Extensions;
using MatchaLatte.Ordering.Api.Models;
using MatchaLatte.Ordering.App.Events;
using MatchaLatte.Ordering.App.Events.Users;
using MatchaLatte.Ordering.Data;
using MatchaLatte.Ordering.Domain.Orders;
using MatchaLatte.Ordering.Queries;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace MatchaLatte.Ordering.Api
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
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove(JwtRegisteredClaimNames.Sub);

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.Configure<PictureSettings>(Configuration.GetSection("Picture"));
            services.AddDbContext<OrderingContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Ordering"));
            });
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
                });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<CurrentUser, CurrentUser>();

            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new AppModule());
            containerBuilder.RegisterModule(new CommandsModule());
            containerBuilder.RegisterModule(new CommonModule(Configuration.GetConnectionString("EventBus")));
            containerBuilder.RegisterModule(new DataModule());
            containerBuilder.RegisterModule(new QueriesModule(Configuration.GetConnectionString("Ordering")));
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

            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var ex = context.Features.Get<IExceptionHandlerFeature>();
                    if (ex != null)
                    {
                        if (ex.Error is DomainException)
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var json = $@"{{ ""Message"": ""{ex.Error.ToString()}"" }}";
                        await context.Response.WriteAsync(json).ConfigureAwait(false);
                    }
                }
            });
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
            app.UseEventBus();
        }
    }
}