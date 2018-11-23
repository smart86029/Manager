using System;
using System.Collections.Generic;

namespace MatchaLatte.Ordering.App.Queries.Stores
{
    public class StoreDetail
    {
        public Guid StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public ICollection<ProductCategoryDetail> ProductCategories { get; set; } = new List<ProductCategoryDetail>();
    }
}