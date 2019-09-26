using System;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Identity.App.Permissions
{
    public class UpdatePermissionCommand : ICommand<bool>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsEnabled { get; set; }
    }
}