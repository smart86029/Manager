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
        /// 初始化 <see cref="OrderItemProductAccessory"/> 類別的新執行個體。
        /// </summary>
        private OrderItemProductAccessory()
        {
        }

        /// <summary>
        /// 初始化 <see cref="OrderItemProductAccessory"/> 類別的新執行個體。
        /// </summary>
        /// <param name="productAccessoryId">商品配件 ID。</param>
        /// <param name="productAccessoryName">商品配件名稱。</param>
        /// <param name="productAccessoryPrice">商品配件價格。</param>
        public OrderItemProductAccessory(Guid productAccessoryId, string productAccessoryName, decimal productAccessoryPrice)
        {
            ProductAccessoryId = productAccessoryId;
            ProductAccessoryName = productAccessoryName;
            ProductAccessoryPrice = productAccessoryPrice;
        }

        /// <summary>
        /// 取得訂單項目 ID。
        /// </summary>
        /// <value>訂單項目 ID。</value>
        public Guid OrderItemId { get; private set; }

        /// <summary>
        /// 取得商品配件 ID。
        /// </summary>
        /// <value>商品配件 ID。</value>
        public Guid ProductAccessoryId { get; private set; }

        /// <summary>
        /// 取得商品配件名稱。
        /// </summary>
        /// <value>商品配件名稱。</value>
        public string ProductAccessoryName { get; private set; }

        /// <summary>
        /// 取得商品配件價格。
        /// </summary>
        /// <value>商品配件價格。</value>
        public decimal ProductAccessoryPrice { get; private set; }
    }
}