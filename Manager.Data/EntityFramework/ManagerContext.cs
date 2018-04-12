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
            //Configuration.ProxyCreationEnabled = false;
            //Configuration.LazyLoadingEnabled = false;
        }

        /// <summary>
        /// 取得或設定店家的集合。
        /// </summary>
        /// <value>店家的集合。</value>
        public DbSet<Store> Stores { get; set; }

        /// <summary>
        /// 取得或設定商品的集合。
        /// </summary>
        /// <value>商品的集合。</value>
        public DbSet<Product> Products { get; set; }

        /// <summary>
        /// 取得或設定商業實體的集合。
        /// </summary>
        /// <value>商業實體的集合。</value>
        public DbSet<BusinessEntity> BusinessEntiteis { get; set; }

        /// <summary>
        /// 取得或設定菜單的集合。
        /// </summary>
        /// <value>菜單的集合。</value>
        public DbSet<Menu> Menus { get; set; }

        /// <summary>
        /// 取得或設定角色的集合。
        /// </summary>
        /// <value>角色的集合。</value>
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// 取得或設定使用者的集合。
        /// </summary>
        /// <value>使用者的集合。</value>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// 此方法的呼叫時機是在初始化衍生內容的模型時，但在鎖定此模型及使用此模型初始化內容之前。 此方法的預設實作不會做任何事，
        /// 但是可以在衍生類別中覆寫它，以便可以進一步設定此模型然後再將它鎖定。
        /// </summary>
        /// <param name="modelBuilder">針對建立的內容定義模型的產生器。</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Store>()
                .HasOne(s => s.Updater)
                .WithMany()
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(x => new { x.UserId, x.RoleId });
                entity.HasOne(x => x.User)
                    .WithMany(u => u.UserRoles)
                    .HasForeignKey(x => x.UserId);
                entity.HasOne(x => x.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(x => x.RoleId);
            });

            modelBuilder.Entity<RoleMenu>(entity =>
            {
                entity.HasKey(x => new { x.RoleId, x.MenuId });
                entity.HasOne(x => x.Role)
                    .WithMany(u => u.RoleMenus)
                    .HasForeignKey(x => x.RoleId);
                entity.HasOne(x => x.Menu)
                    .WithMany(r => r.RoleMenus)
                    .HasForeignKey(x => x.MenuId);
            });
        }
    }
}