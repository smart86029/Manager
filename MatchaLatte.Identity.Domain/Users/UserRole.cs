using System;
using MatchaLatte.Identity.Domain.Roles;

namespace MatchaLatte.Identity.Domain.Users
{
    /// <summary>
    /// 使用者角色。
    /// </summary>
    public class UserRole
    {
        /// <summary>
        /// 初始化 <see cref="UserRole"/> 類別的新執行個體。
        /// </summary>
        private UserRole()
        {
        }

        /// <summary>
        /// 初始化 <see cref="UserRole"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <param name="roleId">角色 ID。</param>
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }

        /// <summary>
        /// 取得使用者 ID。
        /// </summary>
        /// <value>使用者 ID。</value>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 取得角色 ID。
        /// </summary>
        /// <value>角色 ID。</value>
        public Guid RoleId { get; private set; }

        /// <summary>
        /// 取得使用者。
        /// </summary>
        /// <value>使用者。</value>
        public User User { get; private set; }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <value>角色。</value>
        public Role Role { get; private set; }
    }
}