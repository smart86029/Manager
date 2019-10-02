using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.App.Orders
{
    public class OrderStockRejected : Event
    {
        public OrderStockRejected(Guid orderId, string error) : this(orderId, error, new List<InvalidOrderItemDto>())
        {
        }

        public OrderStockRejected(Guid orderId, string error, IEnumerable<InvalidOrderItemDto> invalidOrderItems)
        {
            OrderId = orderId;
            Error = error;
            InvalidOrderItems = invalidOrderItems.ToList();
        }

        public Guid OrderId { get; private set; }

        public string Error { get; private set; }

        public IReadOnlyCollection<InvalidOrderItemDto> InvalidOrderItems { get; private set; }
    }
}