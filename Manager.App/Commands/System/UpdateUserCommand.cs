using System.Collections.Generic;

namespace Manager.App.Commands.System
{
    public class UpdateUserCommand : ICommand
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<Role> Roles { get; set; }

        public class Role
        {
            public int RoleId { get; set; }
            public string Name { get; set; }
            public bool IsChecked { get; set; }
        }
    }
}