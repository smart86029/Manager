using System;

namespace MatchaLatte.Identity.App.Queries.Permissions
{
    public class PermissionDetail
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}