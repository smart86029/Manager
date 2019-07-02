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
        public OrderItem(Guid productId, string productName, Guid productItemId, string productItemName, decimal productItemPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductItemId = productItemId;
            ProductItemName = productItemName;
            ProductItemPrice = productItemPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// 取得商品 ID。
        /// </summary>
        public Guid ProductId { get; private set; }

        /// <summary>
        /// 取得商品名稱。
        /// </summary>
        public string ProductName { get; private set; }

        /// <summary>
        /// 取得商品項目 ID。
        /// </summary>
        public Guid ProductItemId { get; private set; }

        /// <summary>
        /// 取得商品項目名稱。
        /// </summary>
        public string ProductItemName { get; private set; }

        /// <summary>
        /// 取得商品項目價格。
        /// </summary>
        public decimal ProductItemPrice { get; private set; }

        /// <summary>
        /// 取得數量。
        /// </summary>
        public int Quantity { get; private set; }

        /// <summary>
        /// 取得訂單 ID。
        /// </summary>
        public Guid OrderId { get; private set; }

        /// <summary>
        /// 取得訂單項目商品配件的集合。
        /// </summary>
        public IReadOnlyCollection<OrderItemProductAccessory> OrderItemProductAccessories => orderItemProductAccessories;
    }
}