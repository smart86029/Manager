using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;
using MatchaLatte.Identity.Domain.Permissions;
using MatchaLatte.Identity.Domain.Users;

namespace MatchaLatte.Identity.Domain.Roles
{
    /// <summary>
    /// 角色。
    /// </summary>
    public class Role : AggregateRoot
    {
        private readonly List<UserRole> userRoles = new List<UserRole>();
        private readonly List<RolePermission> rolePermissions = new List<RolePermission>();

        /// <summary>
        /// 初始化 <see cref="Role"/> 類別的新執行個體。
        /// </summary>
        private Role()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Role"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public Role(string name, bool isEnabled)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 取得使用者角色的集合。
        /// </summary>
        /// <value>使用者角色的集合。</value>
        public IReadOnlyCollection<UserRole> UserRoles => userRoles.AsReadOnly();

        /// <summary>
        /// 取得角色權限的集合。
        /// </summary>
        /// <value>角色權限的集合。</value>
        public IReadOnlyCollection<RolePermission> RolePermissions => rolePermissions.AsReadOnly();

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name;
        }

        /// <summary>
        /// 啟用。
        /// </summary>
        public void Enable()
        {
            IsEnabled = true;
        }

        /// <summary>
        /// 停用。
        /// </summary>
        public void Disable()
        {
            IsEnabled = false;
        }

        /// <summary>
        /// 分配權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        public void AssignPermission(Permission permission)
        {
            if (!rolePermissions.Any(x => x.PermissionId == permission.Id))
                rolePermissions.Add(new RolePermission(Id, permission.Id));
        }

        /// <summary>
        /// 取消分配權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        public void UnassignPermission(Permission permission)
        {
            var rolePermission = rolePermissions.FirstOrDefault(x => x.PermissionId == permission.Id);
            if (rolePermission != default(RolePermission))
                rolePermissions.Remove(rolePermission);
        }
    }
}