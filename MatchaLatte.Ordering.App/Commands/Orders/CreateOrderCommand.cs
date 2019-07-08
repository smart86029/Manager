using System;
using System.Collections.Generic;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.Queries.Orders;

namespace MatchaLatte.Ordering.App.Commands.Orders
{
    public class CreateOrderCommand : ICommand<OrderDetail>
    {
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        public List<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}