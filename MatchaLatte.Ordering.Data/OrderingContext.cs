using MatchaLatte.Ordering.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Ordering.Data
{
    public class OrderingContext : DbContext
    {
        /// <summary>
        /// 初始化 <see cref="OrderingContext"/> 類別的新執行個體。
        /// </summary>
        public OrderingContext(DbContextOptions<OrderingContext> options) : base(options)
        {
        }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Ordering");
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductItemConfiguration());
        }
    }
}