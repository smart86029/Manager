using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.App.ViewModels.Token;
using MatchaLatte.Identity.Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace MatchaLatte.Identity.Services
{
    /// <summary>
    /// 令牌服務。
    /// </summary>
    public class TokenService : ITokenService
    {
        private const int ExpireMinutes = 120;

        private readonly IUserRepository userRepository;
        private readonly JwtSettings jwtSettings;
        private readonly SymmetricSecurityKey securityKey;

        /// <summary>
        /// 初始化 <see cref="TokenService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userRepository">使用者存放庫。</param>
        /// <param name="jwtSettings">JWT 設定。</param>
        public TokenService(IUserRepository userRepository, JwtSettings jwtSettings)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.jwtSettings = jwtSettings;
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        }

        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="option">新增令牌選項。</param>
        /// <returns>令牌。</returns>
        public async Task<Token> CreateTokenAsync(CreateTokenOption option)
        {
            var passwordHash = CryptographyUtility.Hash(option.Password);
            var user = await userRepository.GetUserAsync(option.UserName, passwordHash);
            if (user == default(User))
                return default(Token);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(jwtSettings.Issuer,
                jwtSettings.Audience,
                expires: DateTime.Now.AddMinutes(ExpireMinutes),
                signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();
            var token = new Token
            {
                AccessToken = handler.WriteToken(securityToken),
                TokenType = "Bearer",
                ExpiresIn = ExpireMinutes
            };

            return token;
        }
    }
}