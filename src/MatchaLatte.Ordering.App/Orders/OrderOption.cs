using System;
using MatchaLatte.Common.Queries;

namespace MatchaLatte.Ordering.App.Orders
{
    public class OrderOption : PaginationOption
    {
        public OrderQueryType QueryType { get; set; }

        public Guid GroupId { get; set; }

        public Guid BuyerId { get; set; }
    }
}