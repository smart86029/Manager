using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Identity.Domain.Roles;

namespace MatchaLatte.Identity.Domain.Users
{
    /// <summary>
    /// 使用者。
    /// </summary>
    public class User : AggregateRoot
    {
        private readonly List<UserRole> userRoles = new List<UserRole>();
        private readonly List<UserRefreshToken> userRefreshTokens = new List<UserRefreshToken>();

        /// <summary>
        /// 初始化 <see cref="User"/> 類別的新執行個體。
        /// </summary>
        private User()
        {
        }

        /// <summary>
        /// 初始化 <see cref="User"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        /// <param name="password">密碼。</param>
        /// <param name="name">姓名。</param>
        /// <param name="displayName">顯示名稱。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public User(string userName, string password, string name, string displayName, bool isEnabled)
        {
            UserName = userName;
            PasswordHash = CryptographyUtility.Hash(password);
            Name = name?.Trim() ?? string.Empty;
            DisplayName = displayName?.Trim() ?? string.Empty;
            IsEnabled = isEnabled;
            RaiseDomainEvent(new UserCreated(Id, Name, DisplayName));
        }

        /// <summary>
        /// 取得使用者名稱。
        /// </summary>
        /// <value>使用者名稱。</value>
        public string UserName { get; private set; }

        /// <summary>
        /// 取得密碼雜湊。
        /// </summary>
        /// <value>密碼雜湊。</value>
        public string PasswordHash { get; private set; }

        /// <summary>
        /// 取得姓名。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// 取得值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// 取得使用者角色的集合。
        /// </summary>
        /// <value>使用者角色的集合。</value>
        public IReadOnlyCollection<UserRole> UserRoles => userRoles.AsReadOnly();

        /// <summary>
        /// 取得更新令牌的集合。
        /// </summary>
        /// <value>更新令牌的集合。</value>
        public IReadOnlyCollection<UserRefreshToken> UserRefreshTokens => userRefreshTokens.AsReadOnly();

        /// <summary>
        /// 更新使用者名稱。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        public void UpdateUserName(string userName)
        {
            UserName = userName;
        }

        /// <summary>
        /// 更新密碼。
        /// </summary>
        /// <param name="password">密碼。</param>
        public void UpdatePassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
                PasswordHash = CryptographyUtility.Hash(password);
        }

        /// <summary>
        /// 更新姓名。
        /// </summary>
        /// <param name="name">姓名。</param>
        public void UpdateName(string name)
        {
            Name = name?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// 更新顯示名稱。
        /// </summary>
        /// <param name="displayName">顯示名稱。</param>
        public void UpdateDisplayName(string displayName)
        {
            DisplayName = displayName?.Trim() ?? string.Empty;
        }

        /// <summary>
        /// 啟用。
        /// </summary>
        public void Enable()
        {
            IsEnabled = true;
            RaiseDomainEvent(new UserDisabled(Id));
        }

        /// <summary>
        /// 停用。
        /// </summary>
        public void Disable()
        {
            IsEnabled = false;
            RaiseDomainEvent(new UserDisabled(Id));
        }

        /// <summary>
        /// 分配角色。
        /// </summary>
        /// <param name="role">角色。</param>
        public void AssignRole(Role role)
        {
            if (!userRoles.Any(x => x.RoleId == role.Id))
                userRoles.Add(new UserRole(Id, role.Id));
        }

        /// <summary>
        /// 取消分配角色。
        /// </summary>
        /// <param name="role">角色。</param>
        public void UnassignRole(Role role)
        {
            var userRole = userRoles.FirstOrDefault(x => x.RoleId == role.Id);
            if (userRole != default(UserRole))
                userRoles.Remove(userRole);
        }

        /// <summary>
        /// 是否合法的刷新令牌。
        /// </summary>
        /// <param name="refreshToken">刷新令牌。</param>
        /// <returns>合法返回是，否則為否。</returns>
        public bool IsValidRefreshToken(string refreshToken)
        {
            return userRefreshTokens.Any(x => x.RefreshToken == refreshToken && !x.IsExpired);
        }

        /// <summary>
        /// 新增刷新令牌。
        /// </summary>
        /// <param name="interval">間隔。</param>
        /// <returns>刷新令牌。</returns>
        public string CreateRefreshToken(TimeSpan interval)
        {
            var token = new UserRefreshToken(DateTime.UtcNow.Add(interval), Id);
            userRefreshTokens.Add(token);

            return token.RefreshToken;
        }

        /// <summary>
        /// 移除刷新令牌。
        /// </summary>
        /// <param name="refreshToken">刷新令牌。</param>
        public void RemoveRefreshToken(string refreshToken)
        {
            var token = userRefreshTokens.First(t => t.RefreshToken == refreshToken);
            userRefreshTokens.Remove(token);
        }
    }
}