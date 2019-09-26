using System;
using System.Collections.Generic;

namespace MatchaLatte.Catalog.App.Stores
{
    public class ProductCategoryDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Sequence { get; set; }

        public ICollection<ProductDetail> Products { get; set; } = new List<ProductDetail>();
    }
}