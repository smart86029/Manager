using System;
using System.Collections.Generic;
using System.Linq;
using MatchaLatte.Common.Events;

namespace MatchaLatte.Catalog.App.Events.Orders
{
    public class OrderCreated : Event
    {
        public OrderCreated(Guid orderId, Guid groupId, Guid buyerId, IEnumerable<OrderItemDto> orderItems)
        {
            OrderId = orderId;
            GroupId = groupId;
            BuyerId = buyerId;
            OrderItems = orderItems.ToList();
        }

        public Guid OrderId { get; private set; }

        public Guid GroupId { get; private set; }

        public Guid BuyerId { get; private set; }

        public IReadOnlyCollection<OrderItemDto> OrderItems { get; private set; }
    }
}