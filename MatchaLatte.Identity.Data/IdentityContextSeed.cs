using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MatchaLatte.Identity.Domain.Permissions;
using MatchaLatte.Identity.Domain.Roles;
using MatchaLatte.Identity.Domain.Users;

namespace MatchaLatte.Identity.Data
{
    public class IdentityContextSeed
    {
        private readonly IdentityContext context;

        public IdentityContextSeed(IdentityContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task SeedAsync()
        {
            try
            {
                if (!context.Set<User>().Any())
                {
                    var users = GetUsers();
                    var roles = GetRoles();
                    var permissions = GetPermissions();

                    foreach (var user in users)
                        foreach (var role in roles)
                            user.AssignRole(role);

                    foreach (var role in roles)
                        foreach (var permission in permissions)
                            role.AssignPermission(permission);

                    context.Set<User>().AddRange(users);
                    context.Set<Role>().AddRange(roles);
                    context.Set<Permission>().AddRange(permissions);

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var result = new User[]
            {
                new User("Admin", "123fff", "管理員", string.Empty, true)
            };

            return result;
        }

        private IEnumerable<Role> GetRoles()
        {
            var result = new Role[]
            {
                new Role("Administrator", true),
                new Role("HumanResources", true)
            };

            return result;
        }

        private IEnumerable<Permission> GetPermissions()
        {
            var result = new Permission[]
            {
                new Permission("特殊權限", string.Empty, true),
                new Permission("登入", string.Empty, true)
            };

            return result;
        }
    }
}