using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Manager.Data.EntityFramework;
using Manager.Models;

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
                new Role { Name = "Administrator", IsActivated = true, Users = context.Users.ToList(), Menus = context.Menus.ToList() },
                new Role { Name = "HumanResources", IsActivated = true, Users = context.Users.ToList(), Menus = context.Menus.ToList() },
            };
            roles.ForEach(s => context.Roles.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();
        }
    }
}