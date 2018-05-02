using System;
using System.Collections.Generic;
using System.Linq;
using Manager.Common;
using Manager.Models.GroupBuying;
using Manager.Models.System;

namespace Manager.Data.EntityFramework
{
    public class DbInitializer
    {
        public static void Initialize(ManagerContext context)
        {
            if (context.Users.Any())
                return;

            var users = new List<User>
            {
                new User { UserName = "Admin", PasswordHash = CryptographyUtility.Hash("123fff"), IsEnabled = true }
            };
            users.ForEach(u => context.Users.Add(u));
            context.SaveChanges();

            var menus = new List<Menu>
            {
                new Menu { Name = "首頁", Controller = "Home", Action = "Index", Order = 0, Description = "首頁" },
                new Menu { Name = "系統", Area = "System", Controller = "Home", Action = "Index", Order = 1, Description = "系統" },
                new Menu { Name = "角色管理", Area = "System", Controller = "Account", Action = "RoleManage", Order = 1, Description = "角色管理" },
                new Menu { Name = "使用者管理", Area = "System", Controller = "Account", Action = "UserManage", Order = 1, Description = "使用者管理" },
            };
            menus.ForEach(m => context.Menus.Add(m));
            context.SaveChanges();

            var roles = new List<Role>
            {
                new Role { Name = "Administrator", IsEnabled = true },
                new Role { Name = "HumanResources", IsEnabled = true },
            };
            roles.ForEach(r => context.Roles.Add(r));
            context.SaveChanges();

            var userRoles = new List<UserRole>
            {
                new UserRole { UserId = 1, RoleId = 1 },
                new UserRole { UserId = 1, RoleId = 2 },
            };
            userRoles.ForEach(x => context.Add(x));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store { Name = "韓膳宮", Description = "測試der", Phone = "2658-2882", Address = "台北市內湖區江南街117號", CreatedBy = 1, CreatedOn = DateTime.Now }
            };
            stores.ForEach(s => context.Stores.Add(s));
            context.SaveChanges();

            var productCategories = new List<ProductCategory>
            {
                new ProductCategory { Name = "飯類", StoreId = 1 },
                new ProductCategory { Name = "鍋類", StoreId = 1 },
                new ProductCategory { Name = "特色餐點", StoreId = 1 },
            };
            productCategories.ForEach(x => context.Add(x));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "韓式牛肉烤肉飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 90 } }, ProductCategoryId = 1 },
                new Product { Name = "韓式豬肉烤肉飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 90 } }, ProductCategoryId = 1 },
                new Product { Name = "韓式牛肉拌飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 90 } }, ProductCategoryId = 1 },
                new Product { Name = "韓式豬肉拌飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 90 } }, ProductCategoryId = 1 },
                new Product { Name = "韓式辣雞拌飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 90 } }, ProductCategoryId = 1 },
                new Product { Name = "香腸泡菜炒飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 1 },
                new Product { Name = "鮪魚泡菜炒飯", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 1 },
                new Product { Name = "海鮮豆腐鍋", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 2 },
                new Product { Name = "海鮮泡菜鍋", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 2 },
                new Product { Name = "大醬湯飯鍋", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 2 },
                new Product { Name = "豆腐辣湯鍋", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 2 },
                new Product { Name = "部隊鍋", ProductItems = new List<ProductItem> { new ProductItem { Price = 150 } }, ProductCategoryId = 2 },
                new Product { Name = "辣炒泡麵", ProductItems = new List<ProductItem> { new ProductItem { Price = 100 } }, ProductCategoryId = 3 },
                new Product { Name = "海鮮炒麵", ProductItems = new List<ProductItem> { new ProductItem { Price = 140 } }, ProductCategoryId = 3 },
                new Product { Name = "辣炒年糕", ProductItems = new List<ProductItem> { new ProductItem { Price = 130 } }, ProductCategoryId = 3 },
                new Product { Name = "海鮮煎餅", ProductItems = new List<ProductItem> { new ProductItem { Price = 150 } }, ProductCategoryId = 3 },
            };
            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}