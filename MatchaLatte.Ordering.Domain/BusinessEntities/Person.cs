using System;

namespace MatchaLatte.Ordering.Domain.BusinessEntities
{
    /// <summary>
    /// 人。
    /// </summary>
    public class Person : BusinessEntity
    {
        /// <summary>
        /// 初始化 <see cref="Person"/> 類別的新執行個體。
        /// </summary>
        /// <param name="businessEntityId">商業實體 ID。</param>
        public Person(Guid businessEntityId) : base(businessEntityId)
        {
        }



        /// <summary>
        /// 取得或設定名。
        /// </summary>
        /// <value>名。</value>
        public string FirstName { get; private set; }

        /// <summary>
        /// 取得或設定姓。
        /// </summary>
        /// <value>姓。</value>
        public string LastName { get; private set; }

        /// <summary>
        /// 取得或設定性別。
        /// </summary>
        /// <value>性別。</value>
        public Gender Gender { get; private set; }

        /// <summary>
        /// 取得或設定出生日期。
        /// </summary>
        /// <value>出生日期。</value>
        public DateTime BirthDate { get; private set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        /// <value>顯示名稱。</value>
        public override string DisplayName => FirstName + LastName;
    }
}