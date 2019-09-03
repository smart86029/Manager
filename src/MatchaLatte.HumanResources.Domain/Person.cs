using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Exceptions;

namespace MatchaLatte.HumanResources.Domain
{
    /// <summary>
    /// 人。
    /// </summary>
    public abstract class Person : AggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="Person"/> 類別的新執行個體。
        /// </summary>
        protected Person()
        {
        }

        /// <summary>
        /// 初始化 <see cref="Person"/> 類別的新執行個體。
        /// </summary>
        /// <param name="name">姓名。</param>
        /// <param name="displayName">顯示名稱。</param>
        /// <param name="birthDate">出生日期。</param>
        /// <param name="gender">性別。</param>
        /// <param name="maritalStatus">婚姻狀況。</param>
        protected Person(string name, string displayName, DateTime birthDate, Gender gender, MaritalStatus maritalStatus)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new DomainException("姓名不能為空");
            if (string.IsNullOrWhiteSpace(displayName))
                throw new DomainException("顯示名稱不能為空");

            Name = name.Trim();
            DisplayName = displayName.Trim();
            BirthDate = birthDate.Date;
            Gender = gender;
            MaritalStatus = maritalStatus;
        }

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