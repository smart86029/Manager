using System.Threading.Tasks;
using Manager.App.Commands;

namespace Manager.Commands
{
    internal interface ICommandHandler<TResult>
    {
        Task<TResult> Handle(ICommand command);
    }

    internal interface ICommandHandler<in TCommand, TResult> : ICommandHandler<TResult> where TCommand : ICommand
    {
    }
}