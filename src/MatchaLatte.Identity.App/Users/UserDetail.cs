using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.Users
{
    public class UserDetail
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<RoleDetail> Roles { get; set; } = new List<RoleDetail>();
    }
}