using System.Collections.Generic;
using MatchaLatte.Common.Commands;
using MatchaLatte.Identity.App.Queries.Users;

namespace MatchaLatte.Identity.App.Commands.Users
{
    public class CreateUserCommand : ICommand<UserDetail>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsEnabled { get; set; }

        public ICollection<RoleDto> Roles { get; set; }
    }
}