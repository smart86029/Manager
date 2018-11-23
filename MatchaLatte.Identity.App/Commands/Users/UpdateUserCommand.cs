using System;
using System.Collections.Generic;

namespace MatchaLatte.Identity.App.Commands.Users
{
    public class UpdateUserCommand
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsEnabled { get; set; }
        public ICollection<RoleDto> Roles { get; set; }
    }
}