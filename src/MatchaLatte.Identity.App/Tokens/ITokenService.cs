using System.Threading.Tasks;

namespace MatchaLatte.Identity.App.Tokens
{
    /// <summary>
    /// 令牌服務。
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="command">新增令牌命令。</param>
        /// <returns>令牌。</returns>
        Task<TokenDetail> CreateTokenAsync(CreateTokenCommand command);

        /// <summary>
        /// 刷新令牌。
        /// </summary>
        /// <param name="command">刷新令牌命令。</param>
        /// <returns>令牌。</returns>
        Task<TokenDetail> RefreshTokenAsync(RefreshTokenCommand command);
    }
}