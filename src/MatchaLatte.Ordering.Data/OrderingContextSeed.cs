using System;
using System.Threading.Tasks;

namespace MatchaLatte.Ordering.Data
{
    public class OrderingContextSeed
    {
        private readonly OrderingContext context;

        public OrderingContextSeed(OrderingContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SeedAsync()
        {
            await Task.CompletedTask;
        }
    }
}