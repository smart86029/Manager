using System;
using System.Collections.Generic;

namespace MatchaLatte.Catalog.App.Stores
{
    public class ProductCategoryDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDefault { get; set; }

        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}