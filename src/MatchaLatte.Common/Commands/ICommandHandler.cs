using System.Threading.Tasks;

namespace MatchaLatte.Common.Commands
{
    /// <summary>
    /// 命令處理常式。
    /// </summary>
    /// <typeparam name="TCommand">命令類型。</typeparam>
    /// <typeparam name="TResult">結果類型。</typeparam>
    public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand<TResult>
    {
        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>結果。</returns>
        Task<TResult> HandleAsync(TCommand command);
    }
}