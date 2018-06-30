namespace Manager.App.Commands.System
{
    public class CreateRoleCommand : ICommand
    {
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}