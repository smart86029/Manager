using System;
using System.Collections.Generic;
using MatchaLatte.Common.Attributes;

namespace MatchaLatte.Ordering.App.Queries.Stores
{
    public class ProductCategoryDetail
    {
        public Guid ProductCategoryId { get; set; }

        [Column("CategoryName")]
        public string Name { get; set; }

        public ICollection<ProductDetail> Products { get; set; } = new List<ProductDetail>();
    }
}