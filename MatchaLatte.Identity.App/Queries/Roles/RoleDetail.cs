using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.Queries.Roles
{
    public class RoleDetail
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<PermissionDetail> Permissions { get; set; } = new List<PermissionDetail>();
    }
}