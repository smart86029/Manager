using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.HumanResources.Domain.JobTitles
{
    /// <summary>
    /// 職稱。
    /// </summary>
    public class JobTitle : AggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="JobTitle"/> 類別的新執行個體。
        /// </summary>
        private JobTitle()
        {
        }

        /// <summary>
        /// 初始化 <see cref="JobTitle"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">名稱。</param>
        /// <param name="isEnabled">是否啟用。</param>
        public JobTitle(string name, bool isEnabled)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");

            Name = name.Trim();
            IsEnabled = isEnabled;
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

            Name = name.Trim();
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