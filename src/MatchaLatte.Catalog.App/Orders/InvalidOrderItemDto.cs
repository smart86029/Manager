using System;

namespace MatchaLatte.Catalog.App.Orders
{
    public class InvalidOrderItemDto
    {
        public InvalidOrderItemDto(OrderItemDto orderItem, string error)
        {
            ProductId = orderItem.ProductId;
            ProductItemId = orderItem.ProductItemId;
            Error = error;
        }

        public Guid ProductId { get; private set; }

        public Guid ProductItemId { get; private set; }

        public string Error { get; private set; }
    }
}