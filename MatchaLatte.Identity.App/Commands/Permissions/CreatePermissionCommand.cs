namespace MatchaLatte.Identity.App.Commands.Permissions
{
    public class CreatePermissionCommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}