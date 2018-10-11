using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Manager.Data.Configurations.System;
using Manager.Domain;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data
{
    /// <summary>
    /// 系統內容。
    /// </summary>
    public class SystemContext : DbContext
    {
        private DomainEventDispatcher dispatcher;

        /// <summary>
        /// 初始化 <see cref="SystemContext"/> 類別的新執行個體。
        /// </summary>
        public SystemContext(DbContextOptions<SystemContext> options, DomainEventDispatcher dispatcher) : base(options)
        {
            this.dispatcher = dispatcher;
        }

        /// <summary>
        /// 將此內容中所做的所有變更非同步儲存到基礎資料庫。
        /// </summary>
        /// <param name="cancellationToken">取消作業。</param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var domainEntities = ChangeTracker.Entries<Entity>().Where(x => x.Entity.DomainEvents.Any()).ToList();
            var domainEvents = domainEntities.SelectMany(x => x.Entity.DomainEvents).ToList();

            domainEntities.ForEach(x => x.Entity.AcceptChanges());

            var tasks = domainEvents.Select(async domainEvent => await dispatcher.DispatchAsync(domainEvent));

            await Task.WhenAll(tasks);

            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("System");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }
    }
}