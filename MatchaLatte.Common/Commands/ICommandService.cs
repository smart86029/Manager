using System.Threading.Tasks;

namespace MatchaLatte.Common.Commands
{
    /// <summary>
    /// 命令服務。
    /// </summary>
    public interface ICommandService
    {
        /// <summary>
        /// 執行。
        /// </summary>
        /// <typeparam name="TResult">結果類型。</typeparam>
        /// <param name="command">命令。</param>
        /// <returns>結果。</returns>
        Task<TResult> ExecuteAsync<TResult>(ICommand<TResult> command);
    }
}