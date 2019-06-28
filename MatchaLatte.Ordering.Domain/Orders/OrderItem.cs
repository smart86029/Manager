using System;
using System.Collections.Generic;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.Orders
{
    /// <summary>
    /// 訂單項目。
    /// </summary>
    public class OrderItem : Entity
    {
        private List<OrderItemProductAccessory> orderItemProductAccessories = new List<OrderItemProductAccessory>();

        /// <summary>
        /// 初始化 <see cref="OrderItem"/> 類別的新執行個體。
        /// </summary>
        private OrderItem()
        {
        }

        /// <summary>
        /// 初始化 <see cref="OrderItem"/> 類別的新執行個體。
        /// </summary>
        /// <param name="productItemId">商品項目 ID。</param>
        /// <param name="productItemName">商品項目名稱。</param>
        /// <param name="productItemPrice">商品項目價格。</param>
        /// <param name="quantity">數量。</param>
        public OrderItem(Guid productItemId, string productItemName, decimal productItemPrice, int quantity)
        {
            ProductItemId = productItemId;
            ProductItemName = productItemName;
            ProductItemPrice = productItemPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// 取得商品項目 ID。
        /// </summary>
        /// <value>商品項目 ID。</value>
        public Guid ProductItemId { get; private set; }

        /// <summary>
        /// 取得商品項目名稱。
        /// </summary>
        /// <value>名稱。</value>
        public string ProductItemName { get; private set; }

        /// <summary>
        /// 取得商品項目價格。
        /// </summary>
        /// <value>價格。</value>
        public decimal ProductItemPrice { get; private set; }

        /// <summary>
        /// 取得數量。
        /// </summary>
        /// <value>數量。</value>
        public int Quantity { get; private set; }

        /// <summary>
        /// 取得訂單 ID。
        /// </summary>
        /// <value>訂單 ID。</value>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// 取得訂單項目商品配件的集合。
        /// </summary>
        /// <value>訂單項目商品配件的集合。</value>
        public IReadOnlyCollection<OrderItemProductAccessory> OrderItemProductAccessories => orderItemProductAccessories;
    }
}