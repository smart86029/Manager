using System;
using System.Threading.Tasks;
using MatchaLatte.Catalog.Domain;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.Data
{
    public class CatalogUnitOfWork : ICatalogUnitOfWork
    {
        private readonly CatalogContext context;
        private readonly IEventBus eventBus;

        public CatalogUnitOfWork(CatalogContext context, IEventBus eventBus)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
            this.eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task<bool> CommitAsync()
        {
            await context.SaveChangesAsync();

            return true;
        }
    }
}