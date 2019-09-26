using System;

namespace MatchaLatte.Identity.App.Permissions
{
    public class PermissionDetail
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }
    }
}