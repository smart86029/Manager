using System;

namespace MatchaLatte.Catalog.App.Events.Orders
{
    public class OrderItemDto
    {
        public OrderItemDto(Guid productId, string productName, Guid productItemId, string productItemName, decimal productItemPrice, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            ProductItemId = productItemId;
            ProductItemName = productItemName;
            ProductItemPrice = productItemPrice;
            Quantity = quantity;
        }

        public Guid ProductId { get; private set; }

        public string ProductName { get; private set; }

        public Guid ProductItemId { get; private set; }

        public string ProductItemName { get; private set; }

        public decimal ProductItemPrice { get; private set; }

        public int Quantity { get; private set; }
    }
}