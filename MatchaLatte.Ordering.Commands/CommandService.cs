using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.Commands
{
    /// <summary>
    /// 命令服務。
    /// </summary>
    public class CommandService : ICommandService
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 初始化 <see cref="CommandService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="serviceProvider">服務提供者。</param>
        public CommandService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 執行。
        /// </summary>
        /// <typeparam name="TResult">結果類型。</typeparam>
        /// <param name="command">命令。</param>
        /// <returns>結果。</returns>
        public async Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command)
        {
            var commandType = command.GetType();
            var handlerAdapter = serviceProvider.GetService(typeof(CommandHandlerAdapter<,>).MakeGenericType(commandType, typeof(TResult)))
                as ICommandHandlerAdapter<TResult>;

            return await handlerAdapter.HandleAsync(command);
        }
    }
}