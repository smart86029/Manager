using System;
using System.Collections.Generic;

namespace MatchaLatte.Ordering.App.Commands.Stores
{
    public class ProductCategoryDto
    {
        public Guid ProductCategoryId { get; set; }
        public string Name { get; set; }
        public ICollection<ProductDto> Products { get; set; } = new List<ProductDto>();
    }
}