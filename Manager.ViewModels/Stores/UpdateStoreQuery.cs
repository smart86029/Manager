using System.Collections.Generic;

namespace Manager.ViewModels.Stores
{
    public class UpdateStoreQuery
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Remark { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public class Product
        {
            public int ProductId { get; set; }
            public string Name { get; set; }
            public decimal Price { get; set; }
        }
    }
}