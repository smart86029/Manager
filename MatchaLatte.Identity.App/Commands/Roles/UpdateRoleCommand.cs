using System;
using System.Collections.Generic;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Commands.Roles
{
    public class UpdateRoleCommand : ICommand<bool>
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<PermissionDto> Permissions { get; set; }
    }
}