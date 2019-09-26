using System;

namespace MatchaLatte.Identity.App.Roles
{
    public class PermissionDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsChecked { get; set; }
    }
}