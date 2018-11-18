using System.Threading.Tasks;
using MatchaLatte.Identity.Data.Configurations;
using MatchaLatte.Identity.Domain;
using Microsoft.EntityFrameworkCore;

namespace MatchaLatte.Identity.Data
{
    /// <summary>
    /// 身分識別內容。
    /// </summary>
    public class IdentityContext : DbContext, IIdentityUnitOfWork
    {
        /// <summary>
        /// 初始化 <see cref="IdentityContext"/> 類別的新執行個體。
        /// </summary>
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        /// <summary>
        /// 提交認可。
        /// </summary>
        /// <returns>成功返回 <c>true</c>，否則為 <c>false</c>。</returns>
        public async Task<bool> CommitAsync()
        {
            await SaveChangesAsync();

            return true;
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