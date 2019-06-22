using System;

namespace MatchaLatte.Identity.App.Commands.Roles
{
    public class PermissionDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}