using System.Collections.Generic;
using MatchaLatte.Common.Commands;
using MatchaLatte.Identity.App.Queries.Roles;

namespace MatchaLatte.Identity.App.Commands.Roles
{
    public class CreateRoleCommand : ICommand<RoleDetail>
    {
        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<PermissionDto> Permissions { get; set; }
    }
}