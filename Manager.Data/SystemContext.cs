using Manager.Data.Configurations.System;
using Microsoft.EntityFrameworkCore;

namespace Manager.Data
{
    /// <summary>
    /// 系統內容。
    /// </summary>
    public class SystemContext : DbContext
    {
        /// <summary>
        /// 初始化 <see cref="SystemContext"/> 類別的新執行個體。
        /// </summary>
        public SystemContext(DbContextOptions<SystemContext> options) : base(options)
        {
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