using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單明細商品配件。
    /// </summary>
    public class OrderItemProductAccessory : Entity
    {
        /// <summary>
        /// 取得或設定訂單明細 ID。
        /// </summary>
        /// <value>訂單明細 ID。</value>
        public Guid OrderDetailId { get; set; }

        /// <summary>
        /// 取得或設定商品配件 ID。
        /// </summary>
        /// <value>商品配件 ID。</value>
        public Guid ProductAccessoryId { get; set; }

        /// <summary>
        /// 取得或設定商品配件名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string ProductAccessoryName { get; set; }

        /// <summary>
        /// 取得或設定商品配件價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal ProductAccessoryPrice { get; set; }

        /// <summary>
        /// 取得或設定訂單明細。
        /// </summary>
        /// <value>訂單明細。</value>
        public OrderItem OrderDetail { get; set; }
    }
}