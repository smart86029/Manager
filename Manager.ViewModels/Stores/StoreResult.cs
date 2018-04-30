using System.Collections.Generic;

namespace Manager.ViewModels.Stores
{
    public class StoreResult
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; }

        public class ProductCategory
        {
            public int ProductCategoryId { get; set; }
            public string Name { get; set; }
            public ICollection<Product> Products { get; set; }
        }

        public class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}