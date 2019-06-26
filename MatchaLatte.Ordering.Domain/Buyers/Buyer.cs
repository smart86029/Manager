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