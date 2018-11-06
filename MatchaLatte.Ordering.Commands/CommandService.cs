using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.Commands
{
    public class CommandService : ICommandService
    {
        private IServiceProvider serviceProvider;

        public CommandService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public async Task<TResult> ExecuteAsync<TResult>(ICommand command)
        {
            var commandType = command.GetType();
            var handler = serviceProvider.GetService(typeof(ICommandHandler<,>).MakeGenericType(commandType, typeof(TResult))) as ICommandHandler<TResult>;

            return await handler.HandleAsync(command);
        }
    }
}
