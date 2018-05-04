using System;

namespace Manager.Models.Generic
{
    /// <summary>
    /// 人。
    /// </summary>
    public class Person : BusinessEntity
    {
        /// <summary>
        /// 取得或設定名。
        /// </summary>
        /// <value>名。</value>
        public string FirstName { get; set; }

        /// <summary>
        /// 取得或設定姓。
        /// </summary>
        /// <value>姓。</value>
        public string LastName { get; set; }

        /// <summary>
        /// 取得或設定性別。
        /// </summary>
        /// <value>性別。</value>
        public Gender Gender { get; set; }

        /// <summary>
        /// 取得或設定出生日期。
        /// </summary>
        /// <value>出生日期。</value>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        /// <value>顯示名稱。</value>
        public override string DisplayName => FirstName + LastName;
    }
}