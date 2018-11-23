using System;

namespace MatchaLatte.Identity.App.Commands.Roles
{
    public class PermissionDto
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}