using System;
using MatchaLatte.Common.Attributes;

namespace MatchaLatte.Catalog.App.Queries.Stores
{
    public class ProductItemDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}