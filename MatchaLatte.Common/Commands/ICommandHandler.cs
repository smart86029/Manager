using System.Threading.Tasks;

namespace MatchaLatte.Common.Commands
{
    public interface ICommandHandler<TResult>
    {
        Task<TResult> HandleAsync(ICommand command);
    }

    public interface ICommandHandler<in TCommand, TResult> : ICommandHandler<TResult> where TCommand : ICommand
    {
    }
}