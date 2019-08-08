using System;
using System.Collections.Generic;

namespace MatchaLatte.Ordering.App.Queries.Orders
{
    public class OrderSummary
    {
        public Guid Id { get; set; }

        public Guid GroupId { get; set; }

        public Guid BuyerId { get; set; }

        public string BuyerName { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto>();
    }
}