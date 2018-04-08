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
    /// �P���w�ҫ�������Ϊk�������պA�C
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<ManagerContext>
    {
        /// <summary>
        /// ��l�� <see cref="Configuration"/> ���O���s�������C
        /// </summary>
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        /// �b�ɯŬ��̷s�����ध�����A�H�K���\��s��l��ơC
        /// </summary>
        /// <param name="context">�n�Ω��s��l��ƪ����e�C</param>
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
                new Menu { Name = "����", Controller = "Home", Action = "Index", Order = 0, Description = "����" },
                new Menu { Name = "�t��", Area = "System", Controller = "Home", Action = "Index", Order = 1, Description = "�t��" },
                new Menu { Name = "����޲z", Area = "System", Controller = "Account", Action = "RoleManage", Order = 1, Description = "����޲z" },
                new Menu { Name = "�ϥΪ̺޲z", Area = "System", Controller = "Account", Action = "UserManage", Order = 1, Description = "�ϥΪ̺޲z" },
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
                new Store { Name = "�����c", Description = "����der", Phone = "2658-2882", Address = "�x�_������Ϧ��n��117��", CreatedBy = 1, CreatedOn = DateTime.Now, UpdatedBy = 1, UpdatedOn = DateTime.Now }
            };
            stores.ForEach(s => context.Stores.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "�������ׯN�׶�", Price = 90, StoreId = 1 },
                new Product { Name = "�����ަׯN�׶�", Price = 90, StoreId = 1 },
                new Product { Name = "�������שն�", Price = 90, StoreId = 1 },
                new Product { Name = "�����ަשն�", Price = 90, StoreId = 1 },
                new Product { Name = "���������ն�", Price = 90, StoreId = 1 },
                new Product { Name = "���z�w�檣��", Price = 130, StoreId = 1 },
                new Product { Name = "�C���w�檣��", Price = 130, StoreId = 1 },
                new Product { Name = "���A���G��", Price = 130, StoreId = 1 },
                new Product { Name = "���A�w����", Price = 130, StoreId = 1 },
                new Product { Name = "�j�������", Price = 130, StoreId = 1 },
                new Product { Name = "���G������", Price = 130, StoreId = 1 },
                new Product { Name = "������", Price = 150, StoreId = 1 },
                new Product { Name = "�����w��", Price = 100, StoreId = 1 },
                new Product { Name = "���A����", Price = 140, StoreId = 1 },
                new Product { Name = "�����~�|", Price = 130, StoreId = 1 },
                new Product { Name = "���A�λ�", Price = 150, StoreId = 1 },
            };
            products.ForEach(s => context.Products.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}