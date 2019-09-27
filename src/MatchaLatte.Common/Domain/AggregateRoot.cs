using System;

namespace MatchaLatte.Common.Domain
{
    /// <summary>
    /// 聚合根。
    /// </summary>
    public class AggregateRoot : Entity
    {
        /// <summary>
        /// 初始化 <see cref="AggregateRoot"/> 類別的新執行個體。
        /// </summary>
        protected AggregateRoot()
        {
        }

        /// <summary>
        /// 初始化 <see cref="AggregateRoot"/> 類別的新執行個體。
        /// </summary>
        /// <param name="id">主鍵。</param>
        protected AggregateRoot(Guid id) : base(id)
        {
        }
    }
}