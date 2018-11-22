using System;
using System.Threading.Tasks;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.Commands
{
    /// <summary>
    /// 命令處理常式轉接器。
    /// </summary>
    /// <typeparam name="TCommand">命令類型。</typeparam>
    /// <typeparam name="TResult">結果類型。</typeparam>
    public class CommandHandlerAdapter<TCommand, TResult> : ICommandHandlerAdapter<TResult> where TCommand : ICommand<TResult>
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// 初始化 <see cref="CommandHandlerAdapter"/> 類別的新執行個體。
        /// </summary>
        /// <param name="serviceProvider">服務提供者。</param>
        public CommandHandlerAdapter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>結果。</returns>
        public Task<TResult> HandleAsync(ICommand<TResult> command)
        {
            var commandType = command.GetType();
            var handler = serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResult>)) as ICommandHandler<TCommand, TResult>;

            return handler.HandleAsync((TCommand)command);
        }
    }
}