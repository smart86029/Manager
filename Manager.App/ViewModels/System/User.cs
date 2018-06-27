using System.Collections.Generic;

namespace Manager.App.ViewModels.System
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Role> Roles { get; set; } = new List<Role>();

        public class Role
        {
            public int RoleId { get; set; }
            public string Name { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}