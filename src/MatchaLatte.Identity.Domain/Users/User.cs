﻿using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;
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
            if (string.IsNullOrWhiteSpace(userName))
                throw new DomainException("使用者名稱不能為空");
            if (string.IsNullOrWhiteSpace(password))
                throw new DomainException("密碼不能為空");
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");

            UserName = userName.Trim();
            PasswordHash = CryptographyUtility.Hash(password.Trim());
            Name = name.Trim();
            DisplayName = displayName.Trim();
            IsEnabled = isEnabled;
            RaiseDomainEvent(new UserCreated(Id, Name, DisplayName));
        }

        /// <summary>
        /// 取得使用者名稱。
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// 取得密碼雜湊。
        /// </summary>
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
        /// 取得是否啟用。
        /// </summary>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 取得建立時間。
        /// </summary>
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// 取得使用者角色的集合。
        /// </summary>
        public IReadOnlyCollection<UserRole> UserRoles => userRoles.AsReadOnly();

        /// <summary>
        /// 取得更新令牌的集合。
        /// </summary>
        public IReadOnlyCollection<UserRefreshToken> UserRefreshTokens => userRefreshTokens.AsReadOnly();

        /// <summary>
        /// 更新使用者名稱。
        /// </summary>
        /// <param name="userName">使用者名稱。</param>
        public void UpdateUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new DomainException("使用者名稱不能為空");

            UserName = userName.Trim();
        }

        /// <summary>
        /// 更新密碼。
        /// </summary>
        /// <param name="password">密碼。</param>
        public void UpdatePassword(string password)
        {
            if (!string.IsNullOrWhiteSpace(password))
                PasswordHash = CryptographyUtility.Hash(password.Trim());
        }

        /// <summary>
        /// 更新姓名。
        /// </summary>
        /// <param name="name">姓名。</param>
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name.Trim();
        }

        /// <summary>
        /// 更新顯示名稱。
        /// </summary>
        /// <param name="displayName">顯示名稱。</param>
        public void UpdateDisplayName(string displayName)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");

            DisplayName = displayName.Trim();
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
        /// 建立刷新令牌。
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