using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.Notification.Domain.Members
{
    /// <summary>
    /// 成員。
    /// </summary>
    public class Member : AggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="Member"/> 類別的新執行個體。
        /// </summary>
        private Member()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Member"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userId">使用者 ID。</param>
        /// <param name="displayName">顯示名稱。</param>
        public Member(Guid userId, string displayName) : base(userId)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");

            DisplayName = displayName.Trim();
        }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        public string DisplayName { get; private set; }
    }
}