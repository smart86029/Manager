using MatchaLatte.Identity.Api.Extensions;
using MatchaLatte.Identity.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MatchaLatte.Identity.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .MigrateDbContext<IdentityContext>((context, services) => new IdentityContextSeed(context).SeedAsync().Wait())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}