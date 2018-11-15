using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Utilities;
using MatchaLatte.Identity.Domain.Roles;

namespace MatchaLatte.Identity.Domain.Permissions
{
    /// <summary>
    /// 權限。
    /// </summary>
    public class Permission : Entity, IAggregateRoot
    {
        private readonly List<RolePermission> rolePermissions = new List<RolePermission>();

        /// <summary>
        /// 初始化 <see cref="Permission"/> 類別的新執行個體。
        /// </summary>
        private Permission()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Permission"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public Permission(string name, string description, bool isEnabled)
            : this(GuidUtility.NewGuid(), name, description, isEnabled)
        {
        }

        /// <summary>
        /// 初始化 <see cref="Permission"/> 類別的新執行個體。
        /// </summary>
        /// <param name="permissionId">權限 ID。</param>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public Permission(Guid permissionId, string name, string description, bool isEnabled)
        {
            PermissionId = permissionId;
            Name = name;
            Description = description;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid PermissionId { get; private set; }

        /// <summary>
        /// 取得名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string Name { get; private set; }

        /// <summary>
        /// 取得描述。
        /// </summary>
        /// <value>描述。</value>
        public string Description { get; private set; }

        /// <summary>
        /// 取得值，這個值指出是否啟用。
        /// </summary>
        /// <value>如果啟用則為 <c>true</c>，否則為 <c>false</c>。</value>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 取得角色權限的集合。
        /// </summary>
        /// <value>角色權限的集合。</value>
        public IReadOnlyCollection<RolePermission> RolePermissions => rolePermissions;

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            Name = name;
        }

        /// <summary>
        /// 更新描述。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateDescription(string description)
        {
            Description = description.Trim() ?? string.Empty;
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
    }
}