using MatchaLatte.Catalog.Api.Extensions;
using MatchaLatte.Catalog.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MatchaLatte.Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .MigrateDbContext<CatalogContext>((context, services) => new CatalogContextSeed(context).SeedAsync().Wait())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}