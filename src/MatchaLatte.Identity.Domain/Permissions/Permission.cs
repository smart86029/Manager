using System.Collections.Generic;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;
using MatchaLatte.Identity.Domain.Roles;

namespace MatchaLatte.Identity.Domain.Permissions
{
    /// <summary>
    /// 權限。
    /// </summary>
    public class Permission : AggregateRoot
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
        /// <param name="code">編碼。</param>
        /// <param name="name">名稱。</param>
        /// <param name="description">描述。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public Permission(string code, string name, string description, bool isEnabled)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException("編碼不能為空");
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Code = code.Trim();
            Name = name.Trim();
            Description = description?.Trim();
            IsEnabled = isEnabled;
        }

        /// <summary>
        /// 取得編碼。
        /// </summary>
        public string Code { get; private set; }

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
        /// 更新編碼。
        /// </summary>
        /// <param name="code">名稱。</param>
        public void UpdateCode(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
                throw new DomainException("編碼不能為空");

            Code = code.Trim();
        }

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name.Trim();
        }

        /// <summary>
        /// 更新描述。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateDescription(string description)
        {
            Description = description?.Trim();
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