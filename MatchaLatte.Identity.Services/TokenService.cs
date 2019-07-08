using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Identity.App.Commands.Tokens;
using MatchaLatte.Identity.App.Queries.Tokens;
using MatchaLatte.Identity.App.Services;
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
        /// <param name="command">新增令牌命令。</param>
        /// <returns>令牌。</returns>
        public async Task<TokenDetail> CreateTokenAsync(CreateTokenCommand command)
        {
            var passwordHash = CryptographyUtility.Hash(command.Password);
            var user = await userRepository.GetUserAsync(command.UserName, passwordHash);
            if (user == default)
                return default(TokenDetail);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(ExpireMinutes),
                signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();
            var token = new TokenDetail
            {
                AccessToken = handler.WriteToken(securityToken),
                TokenType = "Bearer",
                ExpiresIn = ExpireMinutes
            };

            return token;
        }
    }
}