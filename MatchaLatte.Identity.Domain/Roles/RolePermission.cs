using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Identity.Domain.Permissions;

namespace MatchaLatte.Identity.Domain.Roles
{
    /// <summary>
    /// 角色權限。
    /// </summary>
    public class RolePermission : Entity
    {
        /// <summary>
        /// 初始化 <see cref="RolePermission"/> 類別的新執行個體。
        /// </summary>
        private RolePermission()
        {
        }

        /// <summary>
        /// 初始化 <see cref="RolePermission"/> 類別的新執行個體。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <param name="permissionId">權限 ID。</param>
        public RolePermission(Guid roleId, Guid permissionId)
        {
            RoleId = roleId;
            PermissionId = permissionId;
        }

        /// <summary>
        /// 取得角色 ID。
        /// </summary>
        /// <value>角色 ID。</value>
        public Guid RoleId { get; private set; }

        /// <summary>
        /// 取得權限 ID。
        /// </summary>
        /// <value>權限 ID。</value>
        public Guid PermissionId { get; private set; }

        /// <summary>
        /// 取得角色。
        /// </summary>
        /// <value>角色。</value>
        public Role Role { get; private set; }

        /// <summary>
        /// 取得權限。
        /// </summary>
        /// <value>權限。</value>
        public Permission Permission { get; private set; }
    }
}