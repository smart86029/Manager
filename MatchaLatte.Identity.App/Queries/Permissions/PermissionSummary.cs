using System;

namespace MatchaLatte.Identity.App.Queries.Permissions
{
    public class PermissionSummary
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}