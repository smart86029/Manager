using System.Collections.Generic;
using MatchaLatte.Common.Attributes;

namespace MatchaLatte.Ordering.App.ViewModels
{
    public class StoreDetail
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

            public ICollection<Product> Products { get; set; } = new List<Product>();
        }

        public class Product
        {
            public int ProductId { get; set; }

            [Column("ProductName")]
            public string Name { get; set; }

            [Column("ProductDescription")]
            public string Description { get; set; }

            public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
        }

        public class ProductItem
        {
            public int ProductItemId { get; set; }

            [Column("ItemName")]
            public string Name { get; set; }

            public decimal Price { get; set; }
        }
    }
}