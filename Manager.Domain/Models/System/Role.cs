﻿using System.Collections.Generic;
using System.Linq;

namespace Manager.Domain.Models.System
{
    /// <summary>
    /// 角色。
    /// </summary>
    public class Role : Entity, IAggregateRoot
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
            : this(0, name, isEnabled)
        {
        }

        /// <summary>
        /// 初始化 <see cref="Role"/> 類別的新執行個體。
        /// </summary>
        /// <param name="roleId">角色 ID。</param>
        /// <param name="name">名稱。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public Role(int roleId, string name, bool isEnabled)
        {
            RoleId = roleId;
            Name = name;
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public int RoleId { get; private set; }

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
        public IReadOnlyCollection<UserRole> UserRoles => userRoles;

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
            if (!rolePermissions.Any(x => x.RoleId == permission.PermissionId))
                rolePermissions.Add(new RolePermission { Permission = permission });
        }

        /// <summary>
        /// 取消分配權限。
        /// </summary>
        /// <param name="permission">權限。</param>
        public void UnassignPermission(Permission permission)
        {
            var rolePermission = rolePermissions.FirstOrDefault(x => x.PermissionId == permission.PermissionId);
            if (rolePermission != default(RolePermission))
                rolePermissions.Remove(rolePermission);
        }
    }
}