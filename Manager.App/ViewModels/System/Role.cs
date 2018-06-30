using System.Collections.Generic;
using Manager.Common;

namespace Manager.App.ViewModels.System
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Permission> Permissions { get; set; } = new List<Permission>();

        public class Permission
        {
            public int PermissionId { get; set; }

            [Column("PermissionName")]
            public string Name { get; set; }

            public bool IsChecked { get; set; }
        }
    }
}