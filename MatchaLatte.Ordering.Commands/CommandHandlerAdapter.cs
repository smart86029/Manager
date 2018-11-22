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
        private readonly ICommandHandler<TCommand, TResult> handler;

        /// <summary>
        /// 初始化 <see cref="CommandHandlerAdapter"/> 類別的新執行個體。
        /// </summary>
        /// <param name="handler">命令處理常式。</param>
        public CommandHandlerAdapter(ICommandHandler<TCommand, TResult> handler) 
        {
            this.handler = handler;
        }

        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>結果。</returns>
        public Task<TResult> HandleAsync(ICommand<TResult> command)
        {
            return handler.HandleAsync((TCommand)command);
        }
    }
}