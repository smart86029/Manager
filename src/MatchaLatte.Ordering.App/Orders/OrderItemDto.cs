using System;

namespace MatchaLatte.Ordering.App.Orders
{
    public class OrderItemDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public Guid ProductItemId { get; set; }

        public string ProductItemName { get; set; }

        public decimal ProductItemPrice { get; set; }

        public int Quantity { get; set; }
    }
}