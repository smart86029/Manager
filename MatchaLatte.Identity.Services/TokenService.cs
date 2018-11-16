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
    public class TokenService : ITokenService
    {
        private const int ExpireMinutes = 120;

        private readonly IUserRepository userRepository;
        private readonly JwtSettings jwt;
        private readonly SymmetricSecurityKey securityKey;

        public TokenService(IUserRepository userRepository, JwtSettings jwt)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.jwt = jwt;
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
        }

        public async Task<Token> CreateTokenAsync(CreateTokenOption option)
        {
            var passwordHash = CryptographyUtility.Hash(option.Password);
            var user = await userRepository.GetUserAsync(option.UserName, passwordHash);
            if (user == default(User))
                return default(Token);

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(jwt.Issuer,
                jwt.Audience,
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