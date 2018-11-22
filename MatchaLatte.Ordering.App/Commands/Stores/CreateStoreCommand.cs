using System.Collections.Generic;
using MatchaLatte.Common.Commands;
using MatchaLatte.Ordering.App.ViewModels.Stores;

namespace MatchaLatte.Ordering.App.Commands.Stores
{
    public class CreateStoreCommand : ICommand<StoreDetail>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

        public class ProductCategory
        {
            public string Name { get; set; }
            public ICollection<Product> Products { get; set; } = new List<Product>();
        }

        public class Product
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public ICollection<ProductItem> ProductItems { get; set; } = new List<ProductItem>();
        }

        public class ProductItem
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}