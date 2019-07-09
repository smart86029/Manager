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
        /// <param name="firstName">名。</param>
        /// <param name="lastName">姓。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public User(string userName, string password, string firstName, string lastName, bool isEnabled)
        {
            UserName = userName;
            PasswordHash = CryptographyUtility.Hash(password);
            FirstName = firstName;
            LastName = lastName;
            IsEnabled = isEnabled;
            RaiseDomainEvent(new UserCreated(Id));
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
        /// 取得名。
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// 取得姓。
        /// </summary>
        public string LastName { get; private set; }

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
        public IReadOnlyCollection<UserRole> UserRoles => userRoles;

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
    }
}