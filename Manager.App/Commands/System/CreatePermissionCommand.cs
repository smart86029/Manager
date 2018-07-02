namespace Manager.App.Commands.System
{
    public class CreatePermissionCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEnabled { get; set; }
    }
}