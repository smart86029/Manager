using System;
using System.Collections.Generic;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Roles
{
    public class UpdateRoleCommand : ICommand<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<PermissionDto> Permissions { get; set; }
    }
}