namespace Manager.App.Commands.System
{
    public class UpdateRoleCommand : ICommand
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool IsEnabled { get; set; }
    }
}