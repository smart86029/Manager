using System;

namespace MatchaLatte.Ordering.App.Commands.Orders
{
    public class OrderItemDto
    {
        public ProductDto Product { get; set; }

        public ProductItemDto ProductItem { get; set; }

        public int Quantity { get; set; }
    }
}