using System;

namespace MatchaLatte.Identity.App.Commands.Permissions
{
    public class UpdatePermissionCommand
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}