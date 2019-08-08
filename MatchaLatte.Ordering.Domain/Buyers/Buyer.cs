using System;
using MatchaLatte.Common.Domain;

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
        public Buyer(Guid userId, string name, string displayName)
        {
            Id = userId;
            Name = name?.Trim() ?? string.Empty;
            DisplayName = displayName?.Trim() ?? string.Empty;
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