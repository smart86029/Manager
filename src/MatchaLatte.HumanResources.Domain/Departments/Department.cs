using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.HumanResources.Domain.Departments
{
    /// <summary>
    /// 部門。
    /// </summary>
    public class Department : AggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="Department"/> 類別的新執行個體。
        /// </summary>
        private Department()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Department"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="isEnabled">是否啟用。</param>
        /// <param name="parentId">父級 ID。</param>
        public Department(string name, bool isEnabled, Guid? parentId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name?.Trim();
            IsEnabled = isEnabled;
            ParentId = parentId;
        }

        /// <summary>
        /// 名稱。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 取得是否啟用。
        /// </summary>
        public bool IsEnabled { get; private set; }

        /// <summary>
        /// 父級 ID。
        /// </summary>
        public Guid? ParentId { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;

        /// <summary>
        /// 更新名稱。
        /// </summary>
        /// <param name="name">名稱。</param>
        public void UpdateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name?.Trim();
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