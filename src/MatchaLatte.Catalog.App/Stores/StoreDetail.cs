using System;
using System.Collections.Generic;

namespace MatchaLatte.Catalog.App.Stores
{
    public class StoreDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Phone { get; set; }

        public AddressDetail Address { get; set; } = new AddressDetail();

        public string Remark { get; set; }

        public string LogoUri { get; set; }

        public ICollection<ProductCategoryDetail> ProductCategories { get; set; } = new List<ProductCategoryDetail>();
    }
}