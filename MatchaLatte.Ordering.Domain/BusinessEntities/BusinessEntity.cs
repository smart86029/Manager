using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.BusinessEntities
{
    /// <summary>
    /// 商業實體。
    /// </summary>
    public abstract class BusinessEntity : Entity, IAggregateRoot
    {
        /// <summary>
        /// 初始化 <see cref="BusinessEntity"/> 類別的新執行個體。
        /// </summary>
        private BusinessEntity()
        {
        }

        /// <summary>
        /// 初始化 <see cref="BusinessEntity"/> 類別的新執行個體。
        /// </summary>
        /// <param name="businessEntity">商業實體 ID。</param>
        public BusinessEntity(Guid businessEntity)
        {
            BusinessEntityId = businessEntity;
        }

        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid BusinessEntityId { get; private set; }

        /// <summary>
        /// 取得顯示名稱。
        /// </summary>
        /// <value>顯示名稱。</value>
        public abstract string DisplayName { get; }
    }
}