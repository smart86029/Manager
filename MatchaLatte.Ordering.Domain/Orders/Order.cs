using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;
using MatchaLatte.Ordering.Domain.BusinessEntities;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單。
    /// </summary>
    public class Order : AggregateRoot
    {
        private List<OrderDetail> orderDetails = new List<OrderDetail>();
        /// <summary>
        /// 初始化 <see cref="Order"/> 類別的新執行個體。
        /// </summary>
        private Order()
        {
        }


        /// <summary>
        /// 取得主鍵。
        /// </summary>
        /// <value>主鍵。</value>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// 取得應付金額。
        /// </summary>
        /// <value>應付金額。</value>
        public decimal AmountPayable { get; private set; }

        /// <summary>
        /// 取得實付金額。
        /// </summary>
        /// <value>實付金額。</value>
        public decimal AmountPaid { get; private set; }

        /// <summary>
        /// 取得新增者 ID。
        /// </summary>
        /// <value>新增者 ID。</value>
        public Guid CreatedBy { get; private set; }

        /// <summary>
        /// 取得新增時間。
        /// </summary>
        /// <value>新增時間。</value>
        public DateTime CreatedOn { get; private set; }

        /// <summary>
        /// 取得團 ID。
        /// </summary>
        /// <value>團 ID。</value>
        public Guid GroupId { get; private set; }

        /// <summary>
        /// 取得新增者。
        /// </summary>
        /// <value>新增者。</value>
        public BusinessEntity Creator { get; private set; }

        /// <summary>
        /// 取得訂單明細的集合。
        /// </summary>
        /// <value>訂單明細的集合。</value>
        public IReadOnlyCollection<OrderDetail> OrderDetails => orderDetails;
    }
}