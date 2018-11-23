using System;

namespace MatchaLatte.Ordering.App.Commands.Stores
{
    public class ProductItemDto
    {
        public Guid ProductItemId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}