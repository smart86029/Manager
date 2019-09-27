using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.Ordering.Domain.Buyers
{
    /// <summary>
    /// 買家。
    /// </summary>
    public class Buyer : AggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="Buyer"/> 類別的新執行個體。
        /// </summary>
        private Buyer()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Buyer"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <param name="name">姓名。</param>
        /// <param name="displayName">顯示名稱。</param>
        public Buyer(Guid userId, string name, string displayName) : base(userId)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("名稱不能為空");
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");

            Name = name.Trim();
            DisplayName = displayName.Trim();
        }

        /// <summary>
        /// 取得姓名。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        public string DisplayName { get; private set; }
    }
}