using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Identity.App.Commands.Tokens;
using MatchaLatte.Identity.App.Queries.Tokens;
using MatchaLatte.Identity.App.Services;
using MatchaLatte.Identity.Domain;
using MatchaLatte.Identity.Domain.Permissions;
using MatchaLatte.Identity.Domain.Roles;
using MatchaLatte.Identity.Domain.Users;
using Microsoft.IdentityModel.Tokens;

namespace MatchaLatte.Identity.Services
{
    /// <summary>
    /// 令牌服務。
    /// </summary>
    public class TokenService : ITokenService
    {
        private const int AccessTokenExpireSeconds = 60 * 60;
        private const int RefreshTokenExpireSeconds = 24 * 60 * 60;

        private readonly IIdentityUnitOfWork unitOfWork;
        private readonly IUserRepository userRepository;
        private readonly IRoleRepository roleRepository;
        private readonly IPermissionRepository permissionRepository;
        private readonly JwtSettings jwtSettings;
        private readonly SymmetricSecurityKey securityKey;

        /// <summary>
        /// 初始化 <see cref="TokenService"/> 類別的新執行個體。
        /// </summary>
        /// <param name="unitOfWork">工作單元。</param>
        /// <param name="userRepository">使用者存放庫。</param>
        /// <param name="jwtSettings">JWT 設定。</param>
        public TokenService(
            IIdentityUnitOfWork unitOfWork,
            IUserRepository userRepository, 
            IRoleRepository roleRepository,
            IPermissionRepository permissionRepository,
            JwtSettings jwtSettings)
        {
            this.unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            this.roleRepository = roleRepository ?? throw new ArgumentNullException(nameof(roleRepository));
            this.permissionRepository = permissionRepository ?? throw new ArgumentNullException(nameof(permissionRepository));
            this.jwtSettings = jwtSettings;
            securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key));
        }

        /// <summary>
        /// 建立令牌。
        /// </summary>
        /// <param name="command">建立令牌命令。</param>
        /// <returns>令牌。</returns>
        public async Task<TokenDetail> CreateTokenAsync(CreateTokenCommand command)
        {
            var passwordHash = CryptographyUtility.Hash(command.Password);
            var user = await userRepository.GetUserAsync(command.UserName, passwordHash);
            if (user == default)
                return default;

            var accessToken = await CreateAccessTokenAsync(user);
            var refreshToken = user.CreateRefreshToken(TimeSpan.FromSeconds(RefreshTokenExpireSeconds));

            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            var token = new TokenDetail
            {
                AccessToken = accessToken,
                TokenType = "Bearer",
                ExpiresIn = AccessTokenExpireSeconds,
                RefreshToken = refreshToken
            };

            return token;
        }

        /// <summary>
        /// 刷新令牌。
        /// </summary>
        /// <param name="command">刷新令牌命令。</param>
        /// <returns>令牌。</returns>
        public async Task<TokenDetail> RefreshTokenAsync(RefreshTokenCommand command)
        {
            var principal = GetPrincipal(command.AccessToken);
            Guid.TryParse(principal.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub)?.Value, out var userId);
            var user = await userRepository.GetUserAsync(userId);
            if (user == default)
                return default;

            if (!user.IsValidRefreshToken(command.RefreshToken))
                return default;

            user.RemoveRefreshToken(command.RefreshToken);
            var accessToken = CreateAccessTokenAsync(user);
            var refreshToken = user.CreateRefreshToken(TimeSpan.FromSeconds(RefreshTokenExpireSeconds));

            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            var token = new TokenDetail
            {
                AccessToken = await accessToken,
                TokenType = "Bearer",
                ExpiresIn = AccessTokenExpireSeconds,
                RefreshToken = refreshToken
            };

            return token;
        }

        private ClaimsPrincipal GetPrincipal(string accessToken)
        {
            var handler = new JwtSecurityTokenHandler();
            return handler.ValidateToken(accessToken, new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = securityKey,
                ValidateLifetime = false
            }, out SecurityToken validatedToken);
        }

        private async Task<string> CreateAccessTokenAsync(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.UserData, JsonUtility.Serialize(await GetPermissionCodesAsync(user))),
            };
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var securityToken = new JwtSecurityToken(
                jwtSettings.Issuer,
                jwtSettings.Audience,
                claims,
                expires: DateTime.UtcNow.AddSeconds(AccessTokenExpireSeconds),
                signingCredentials: credentials);
            var handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(securityToken);
        }

        private async Task<List<string>> GetPermissionCodesAsync(User user)
        {
            var roleIds = user.UserRoles.Select(x => x.RoleId);
            var roles = await roleRepository.GetRolesAsync(r => roleIds.Contains(r.Id));
            var permissionIds = roles.SelectMany(r => r.RolePermissions).Select(x => x.PermissionId).Distinct();
            var permissions = await permissionRepository.GetPermissionsAsync(p => permissionIds.Contains(p.Id));
            var result = permissions.Select(p => p.Code).ToList();

            return result;
        }
    }
}