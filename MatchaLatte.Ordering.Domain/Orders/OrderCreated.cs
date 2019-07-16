using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Domain;

namespace MatchaLatte.Ordering.Domain.Orders
{
    public class OrderCreated : DomainEvent
    {
        public OrderCreated(Guid orderId, Guid groupId, Guid buyerId, IEnumerable<OrderItem> orderItems)
        {
            OrderId = orderId;
            GroupId = groupId;
            BuyerId = buyerId;
            OrderItems = orderItems.ToList();
        }

        public Guid OrderId { get; private set; }

        public Guid GroupId { get; private set; }

        public Guid BuyerId { get; private set; }

        public IReadOnlyCollection<OrderItem> OrderItems { get; private set; }
    }
}