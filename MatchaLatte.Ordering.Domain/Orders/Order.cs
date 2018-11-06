using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;
using MatchaLatte.Ordering.Domain.BusinessEntities;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單。
    /// </summary>
    public class Order : Entity, IAggregateRoot
    {
        /// <summary>
        /// 取得或設定主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid OrderId { get; set; }

        /// <summary>
        /// 取得或設定應付金額。
        /// </summary>
        /// <value>應付金額。</value>
        public decimal AmountPayable { get; set; }

        /// <summary>
        /// 取得或設定實付金額。
        /// </summary>
        /// <value>實付金額。</value>
        public decimal AmountPaid { get; set; }

        /// <summary>
        /// 取得或設定新增者 ID。
        /// </summary>
        /// <value>新增者 ID。</value>
        public Guid CreatedBy { get; set; }

        /// <summary>
        /// 取得或設定新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// 取得或設定新增者。
        /// </summary>
        /// <value>新增者。</value>
        public BusinessEntity Creator { get; set; }

        /// <summary>
        /// 取得或設定訂單明細的集合。
        /// </summary>
        /// <value>訂單明細的集合。</value>
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}