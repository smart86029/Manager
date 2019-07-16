using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.Queries.Users
{
    public class UserDetail
    {
        public Guid Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<RoleDetail> Roles { get; set; } = new List<RoleDetail>();
    }
}