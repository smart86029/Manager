using System;
using System.Collections.Generic;
using MatchaLatte.Common.Attributes;

namespace MatchaLatte.Ordering.App.Queries.Stores
{
    public class ProductDetail
    {
        public Guid ProductId { get; set; }

        [Column("ProductName")]
        public string Name { get; set; }

        [Column("ProductDescription")]
        public string Description { get; set; }

        public ICollection<ProductItemDetail> ProductItems { get; set; } = new List<ProductItemDetail>();
    }
}