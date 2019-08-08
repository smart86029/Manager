using System;
using System.Collections.Generic;
using System.Text;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.HumanResources.Domain
{
    /// <summary>
    /// 人。
    /// </summary>
    public abstract class Person : AggregateRoot
    {
        /// <summary>
        /// 取得姓名。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        public string DisplayName { get; private set; }

        /// <summary>
        /// 取得出生日期。
        /// </summary>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// 取得性別。
        /// </summary>
        public Gender Gender { get; private set; }

        /// <summary>
        /// 取得婚姻狀況。
        /// </summary>
        public MaritalStatus MaritalStatus { get; private set; }
    }
}
