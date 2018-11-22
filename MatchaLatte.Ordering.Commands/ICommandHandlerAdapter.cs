using System.Threading.Tasks;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.Commands
{
    /// <summary>
    /// 命令處理常式轉接器。
    /// </summary>
    /// <typeparam name="TResult">結果類型。</typeparam>
    public interface ICommandHandlerAdapter<TResult>
    {
        /// <summary>
        /// 處理。
        /// </summary>
        /// <param name="command">命令。</param>
        /// <returns>結果。</returns>
        Task<TResult> HandleAsync(ICommand<TResult> command);
    }
}