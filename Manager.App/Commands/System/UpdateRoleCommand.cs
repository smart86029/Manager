using System.Collections.Generic;

namespace Manager.App.Commands.System
{
    public class UpdateRoleCommand : ICommand
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Permission> Permissions { get; set; }

        public class Permission
        {
            public int PermissionId { get; set; }
            public string Name { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}