﻿using System;
using System.Collections.Generic;
using MatchaLatte.Common.Attributes;

namespace MatchaLatte.Catalog.App.Queries.Stores
{
    public class ProductDetail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Sequence { get; set; }

        public ICollection<ProductItemDetail> ProductItems { get; set; } = new List<ProductItemDetail>();
    }
}