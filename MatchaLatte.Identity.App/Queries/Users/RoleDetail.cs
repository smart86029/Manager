using System;

namespace MatchaLatte.Identity.App.Queries.Users
{
    public class RoleDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}