using MatchaLatte.Ordering.Api.Extensions;
using MatchaLatte.Ordering.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace MatchaLatte.Ordering.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args)
                .Build()
                .MigrateDbContext<OrderingContext>((context, services) => new OrderingContextSeed(context).SeedAsync().Wait())
                .Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}