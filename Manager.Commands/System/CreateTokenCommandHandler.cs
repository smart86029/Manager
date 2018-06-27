using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Manager.App.Commands;
using Manager.App.Commands.System;
using Manager.Common;
using Manager.Domain.Models.System;
using Manager.Domain.Repositories.System;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Commands.System
{
    public class CreateTokenCommandHandler : ICommandHandler<CreateTokenCommand, string>
    {
        private const int ExpireMinutes = 120;

        private readonly IUserRepository userRepository;
        private readonly SymmetricSecurityKey securityKey;
        private readonly string issuer;

        public CreateTokenCommandHandler(IUserRepository userRepository, string key, string issuer)
        {
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            this.issuer = issuer ?? string.Empty;
        }

        public async Task<string> Handle(ICommand command)
        {
            var createTokenCommand = command as CreateTokenCommand ?? throw new NotSupportedException();
            var passwordHash = CryptographyUtility.Hash(createTokenCommand.Password);
            var user = await userRepository.GetUserAsync(createTokenCommand.UserName, passwordHash);
            if (user == default(User))
                return string.Empty;

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer,
                issuer,
                expires: DateTime.Now.AddMinutes(ExpireMinutes),
                signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}