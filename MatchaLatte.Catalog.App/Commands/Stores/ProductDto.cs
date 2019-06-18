using System;
using System.Collections.Generic;

namespace MatchaLatte.Catalog.App.Commands.Stores
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<ProductItemDto> ProductItems { get; set; } = new List<ProductItemDto>();
    }
}