using System.Collections.Generic;

namespace MatchaLatte.Identity.App.ViewModels.Role
{
    public class CreateRoleOption
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<PermissionOption> Permissions { get; set; }
    }
}