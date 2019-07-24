using System;
using System.Collections.Generic;
using System.Text;

namespace MatchaLatte.Ordering.App.Queries.Orders
{
    public class OrderOption : PaginationOption
    {
        public Guid GroupId { get; set; }

        public Guid BuyerId { get; set; }
    }
}
