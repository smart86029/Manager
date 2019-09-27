using System;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Ordering.App.Orders
{
    public class OrderStockConfirmed : Event
    {
        public OrderStockConfirmed(Guid orderId)
        {
            OrderId = orderId;
        }

        public Guid OrderId { get; private set; }
    }
}