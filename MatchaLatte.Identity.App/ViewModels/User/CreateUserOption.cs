using System.Collections.Generic;

namespace MatchaLatte.Identity.App.ViewModels.User
{
    public class CreateUserOption
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<RoleOption> Roles { get; set; }
    }
}