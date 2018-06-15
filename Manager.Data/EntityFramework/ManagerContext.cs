using Manager.Data.EntityFramework.Configurations;
using Manager.Models.Generic;
using Manager.Models.GroupBuying;
using Manager.Models.System;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data.EntityFramework
{
    /// <summary>
    /// 經紀人內容。
    /// </summary>
    public class ManagerContext : DbContext
    {
        /// <summary>
        /// 初始化 <see cref="ManagerContext"/> 類別的新執行個體。
        /// </summary>
        public ManagerContext(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。 此方法的預設實作不會做任何事，
        /// 但是可以在衍生類別中覆寫它，以便可以進一步設定此模型然後再將它鎖定。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BusinessEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PersonConfiguration());

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());

            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new GroupStoreConfiguration());
            modelBuilder.ApplyConfiguration(new ProductCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductAccessoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductOptionConfiguration());
            modelBuilder.ApplyConfiguration(new ProductItemConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());
            modelBuilder.ApplyConfiguration(new OrderDetailProductAccessoryConfiguration());
        }
    }
}