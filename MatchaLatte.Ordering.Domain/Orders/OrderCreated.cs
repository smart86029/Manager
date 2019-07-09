using System;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.Orders
{
    public class OrderCreated : DomainEvent
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