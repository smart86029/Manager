using System;

namespace MatchaLatte.Identity.App.Queries.Roles
{
    public class RoleSummary
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}