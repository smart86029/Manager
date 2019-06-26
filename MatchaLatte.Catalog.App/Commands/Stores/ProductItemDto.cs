﻿using System;

namespace MatchaLatte.Catalog.App.Commands.Stores
{
    public class ProductItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}