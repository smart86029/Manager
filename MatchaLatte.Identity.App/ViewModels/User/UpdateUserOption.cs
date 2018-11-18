using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.ViewModels.User
{
    public class UpdateUserOption
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<RoleOption> Roles { get; set; }
    }
}