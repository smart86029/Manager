using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.ViewModels.Role
{
    public class UpdateRoleOption
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<PermissionOption> Permissions { get; set; }
    }
}