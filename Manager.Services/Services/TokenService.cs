using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Manager.Common;
using Manager.Data;
using Manager.Models;
using Manager.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Services
{
    /// <summary>
    /// 令牌服務。
    /// </summary>
    public class TokenService
    {
        private const string Key = "D2089BE672953D1136FAA84079AF1B6F3967FED8932DABFFBA3032D30E3C0618";
        private const int ExpireMinutes = 120;

        private IUserRepository userRepository;
        private SymmetricSecurityKey securityKey;

        /// <summary>
        /// 初始化 <see cref="TokenService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userRepository">使用者倉儲。</param>
        public TokenService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }

        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="query">新增令牌查詢。</param>
        /// <returns>令牌。</returns>
        public async Task<string> CreateTokenAsync(CreateTokenQuery query)
        {
            var passwordHash = CryptographyUtility.Hash(query.Password);
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserName == query.UserName && u.PasswordHash == passwordHash, u => u.Roles);
            if (user == default(User))
                return string.Empty;

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(ExpireMinutes),
                SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(tokenDescriptor);
            var token = handler.WriteToken(securityToken);

            return token;
        }

        /// <summary>
        /// 取得宣告式身分識別。
        /// </summary>
        /// <param name="token">令牌。</param>
        /// <returns>宣告式身分識別。</returns>
        public ClaimsPrincipal GetPrincipal(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
                if (jwtToken == null)
                    return null;

                var validationParameters = new TokenValidationParameters
                {
                    RequireExpirationTime = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = securityKey
                };
                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validateToken);

                return principal;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}