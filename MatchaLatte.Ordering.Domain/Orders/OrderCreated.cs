using System;
using MatchaLatte.Common.Domain;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Ordering.Domain.Orders
{
    public class OrderCreated : Event, IDomainEvent
    {
        public OrderCreated(Guid orderId, Guid buyerId)
        {
            OrderId = orderId;
            BuyerId = buyerId;
        }

        public Guid OrderId { get; private set; }

        public Guid BuyerId { get; private set; }
    }
}