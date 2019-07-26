using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MatchaLatte.HumanResources.Api.Extensions
{
    internal static class IWebHostExtensions
    {
        internal static IWebHost MigrateDbContext<TContext>(this IWebHost webHost, Action<TContext, IServiceProvider> seeder) where TContext : DbContext
        {
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetService<TContext>();

                try
                {
                    context.Database.Migrate();
                    seeder(context, services);
                }
                catch (Exception)
                {
                }
            }

            return webHost;
        }
    }
}