using System.Threading.Tasks;

namespace Manager.App.Commands.System
{
    public class CreateTokenCommand : ICommand
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}