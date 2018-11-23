using MatchaLatte.Common.Commands;
using MatchaLatte.Identity.App.Queries.Permissions;

namespace MatchaLatte.Identity.App.Commands.Permissions
{
    public class CreatePermissionCommand : ICommand<PermissionDetail>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}