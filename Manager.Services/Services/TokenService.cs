using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Manager.Common;
using Manager.Data;
using Manager.Models.System;
using Manager.ViewModels.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Services
{
    /// <summary>
    /// 令牌服務。
    /// </summary>
    public class TokenService
    {
        private const int ExpireMinutes = 120;

        private IConfiguration config;
        private IUserRepository userRepository;
        private SymmetricSecurityKey securityKey;

        /// <summary>
        /// 初始化 <see cref="TokenService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userRepository">使用者存放庫。</param>
        public TokenService(IConfiguration config, IUserRepository userRepository)
        {
            this.config = config;
            this.userRepository = userRepository;
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
        }

        /// <summary>
        /// 新增令牌。
        /// </summary>
        /// <param name="query">新增令牌查詢。</param>
        /// <returns>令牌。</returns>
        public async Task<string> CreateTokenAsync(CreateTokenQuery query)
        {
            var passwordHash = CryptographyUtility.Hash(query.Password);
            var user = await userRepository.FirstOrDefaultAsync(u => u.UserName == query.UserName && u.PasswordHash == passwordHash);
            if (user == default(User))
                return string.Empty;

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(config["Jwt:Issuer"],
                config["Jwt:Issuer"],
                expires: DateTime.Now.AddMinutes(ExpireMinutes),
                signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }

        /// <summary>
        /// 取得宣告式身分識別。
        /// </summary>
        /// <param name="token">令牌。</param>
        /// <returns>宣告式身分識別。</returns>
        public ClaimsPrincipal GetPrincipal(string token)
        {
            return new ClaimsPrincipal();
            //try
            //{
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            //    if (jwtToken == null)
            //        return null;

            //    var validationParameters = new TokenValidationParameters
            //    {
            //        RequireExpirationTime = true,
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        IssuerSigningKey = securityKey
            //    };
            //    var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validateToken);

            //    return principal;
            //}
            //catch (Exception)
            //{
            //    return null;
            //}
        }
    }
}