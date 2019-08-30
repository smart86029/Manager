using MatchaLatte.HumanResources.Api.Extensions;
using MatchaLatte.HumanResources.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MatchaLatte.HumanResources.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .MigrateDbContext<HumanResourcesContext>((context, services) => new HumanResourcesContextSeed(context).SeedAsync().Wait())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}