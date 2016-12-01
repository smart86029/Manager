using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Manager.Data.EntityFramework;
using Manager.Models;

namespace Manager.Data.Migrations
{
    /// <summary>
    /// 與給定模型之移轉用法有關的組態。
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ManagerContext>
    {
        /// <summary>
        /// 初始化 <see cref="Configuration"/> 類別的新執行個體。
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// 在升級為最新的移轉之後執行，以便允許更新初始資料。
        /// </summary>
        /// <param name="context">要用於更新初始資料的內容。</param>
        protected override void Seed(ManagerContext context)
        {
            var users = new List<User>
            {
            };
            users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            var menus = new List<Menu>
            {
                new Menu { Name = "首頁", Controller = "Home", Action = "Index", Order = 0, Description = "首頁" },
                new Menu { Name = "系統", Area = "System", Controller = "Home", Action = "Index", Order = 1, Description = "系統" },
                new Menu { Name = "角色管理", Area = "System", Controller = "Account", Action = "RoleManage", Order = 1, Description = "角色管理" },
                new Menu { Name = "使用者管理", Area = "System", Controller = "Account", Action = "UserManage", Order = 1, Description = "使用者管理" },
            };
            menus.ForEach(s => context.Menus.AddOrUpdate(p => new { p.Area, p.Controller, p.Action }, s));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role { Name = "Administrator", IsActivated = true, Users = context.Users.ToList(), Menus = context.Menus.ToList() },
                new Role { Name = "HumanResources", IsActivated = true, Users = context.Users.ToList(), Menus = context.Menus.ToList() },
            };
            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}