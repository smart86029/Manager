using System;

namespace MatchaLatte.Identity.App.ViewModels.Role
{
    public class PermissionDetail
    {
        public Guid PermissionId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}