using System.Collections.Generic;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Roles
{
    public class CreateRoleCommand : ICommand<RoleDetail>
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<PermissionDto> Permissions { get; set; }
    }
}