using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Permissions
{
    public class CreatePermissionCommand : ICommand<PermissionDetail>
    {
        public string Code { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }
    }
}