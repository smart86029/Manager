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
        /// <param name="firstName">名。</param>
        /// <param name="lastName">姓。</param>
        public Buyer(Guid userId, string firstName, string lastName)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
        }

        /// <summary>
        /// 取得使用者 ID。
        /// </summary>
        /// <value>使用者 ID。</value>
        public Guid UserId { get; private set; }

        /// <summary>
        /// 取得名。
        /// </summary>
        /// <value>名。</value>
        public string FirstName { get; private set; }

        /// <summary>
        /// 取得姓。
        /// </summary>
        /// <value>姓。</value>
        public string LastName { get; private set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        /// <value>顯示名稱。</value>
        public string DisplayName => FirstName + LastName;
    }
}