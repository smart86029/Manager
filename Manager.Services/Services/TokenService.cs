using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Manager.Data;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Services
{
    public class TokenService
    {
        private const string Key = "D2089BE672953D1136FAA84079AF1B6F3967FED8932DABFFBA3032D30E3C0618";

        private IUserRepository userRepository;
        private SymmetricSecurityKey securityKey;
        private SigningCredentials credentials;

        public TokenService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }

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