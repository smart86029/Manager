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
        /// 取得名。
        /// </summary>
        public string FirstName { get; private set; }

        /// <summary>
        /// 取得姓。
        /// </summary>
        public string LastName { get; private set; }

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
