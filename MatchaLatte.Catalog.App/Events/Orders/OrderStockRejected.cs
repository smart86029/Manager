using System;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.App.Events.Orders
{
    public class OrderStockRejected : Event
    {
        public OrderStockRejected(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}