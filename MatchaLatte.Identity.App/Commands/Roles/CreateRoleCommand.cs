using System.Collections.Generic;

namespace MatchaLatte.Identity.App.Commands.Roles
{
    public class CreateRoleCommand
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<PermissionDto> Permissions { get; set; }
    }
}