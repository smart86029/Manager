using System;

namespace MatchaLatte.Identity.App.ViewModels.User
{
    public class RoleOption
    {
        public Guid RoleId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }
    }
}