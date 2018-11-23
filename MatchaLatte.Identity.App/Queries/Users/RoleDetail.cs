using System;

namespace MatchaLatte.Identity.App.Queries.Users
{
    public class RoleDetail
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}