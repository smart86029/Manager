using System;
using System.Collections.Generic;
using MatchaLatte.Common.Commands;

namespace MatchaLatte.Ordering.App.Orders
{
    public class CreateOrderCommand : ICommand<OrderDetail>
    {
        public Guid GroupId { get; set; }

        public Guid UserId { get; set; }

        public List<CreateOrderItemDto> OrderItems { get; set; } = new List<CreateOrderItemDto>();
    }
}