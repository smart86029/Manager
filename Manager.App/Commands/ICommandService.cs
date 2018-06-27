using System.Threading.Tasks;

namespace Manager.App.Commands
{
    public interface ICommandService
    {
        Task<TResult> ExecuteAsync<TResult>(ICommand command);
    }
}