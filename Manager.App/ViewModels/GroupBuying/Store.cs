using System.Collections.Generic;
using Manager.Common;

namespace Manager.App.ViewModels.GroupBuying
{
    public class Store
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public class ProductCategory
        {
            public int ProductCategoryId { get; set; }

            [Column("CategoryName")]
            public string Name { get; set; }
        }
    }
}