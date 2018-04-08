using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Manager.Common;
using Manager.Data.EntityFramework;
using Manager.Models;
using Manager.Models.GroupBuying;
using Manager.Models.System;

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
                new User { UserName = "Admin", PasswordHash = CryptographyUtility.Hash("123fff"), IsEnabled = true }
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
                new Role { Name = "Administrator", IsEnabled = true, Users = context.Users.ToList(), Menus = context.Menus.ToList() },
                new Role { Name = "HumanResources", IsEnabled = true, Users = context.Users.ToList(), Menus = context.Menus.ToList() },
            };
            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store { Name = "韓膳宮", Description = "測試der", Phone = "2658-2882", Address = "台北市內湖區江南街117號", CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now }
            };
            stores.ForEach(s => context.Stores.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "韓式牛肉烤肉飯", Price = 90, StoreId = 1 },
                new Product { Name = "韓式豬肉烤肉飯", Price = 90, StoreId = 1 },
                new Product { Name = "韓式牛肉拌飯", Price = 90, StoreId = 1 },
                new Product { Name = "韓式豬肉拌飯", Price = 90, StoreId = 1 },
                new Product { Name = "韓式辣雞拌飯", Price = 90, StoreId = 1 },
                new Product { Name = "香腸泡菜炒飯", Price = 130, StoreId = 1 },
                new Product { Name = "鮪魚泡菜炒飯", Price = 130, StoreId = 1 },
                new Product { Name = "海鮮豆腐鍋", Price = 130, StoreId = 1 },
                new Product { Name = "海鮮泡菜鍋", Price = 130, StoreId = 1 },
                new Product { Name = "大醬湯飯鍋", Price = 130, StoreId = 1 },
                new Product { Name = "豆腐辣湯鍋", Price = 130, StoreId = 1 },
                new Product { Name = "部隊鍋", Price = 150, StoreId = 1 },
                new Product { Name = "辣炒泡麵", Price = 100, StoreId = 1 },
                new Product { Name = "海鮮炒麵", Price = 140, StoreId = 1 },
                new Product { Name = "辣炒年糕", Price = 130, StoreId = 1 },
                new Product { Name = "海鮮煎餅", Price = 150, StoreId = 1 },
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}