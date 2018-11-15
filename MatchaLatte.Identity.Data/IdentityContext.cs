using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MatchaLatte.Identity.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Identity.Data
{
    public class IdentityContext : DbContext
    {
        /// <summary>
        /// 初始化 <see cref="IdentityContext"/> 類別的新執行個體。
        /// </summary>
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        /// <summary>
        /// 將此內容中所做的所有變更非同步儲存到基礎資料庫。
        /// </summary>
        /// <param name="cancellationToken">取消作業。</param>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            return await base.SaveChangesAsync(cancellationToken);
        }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Identity");
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new PermissionConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new RolePermissionConfiguration());
        }
    }
}
