﻿using System;

namespace MatchaLatte.Ordering.App.Commands.Orders
{
    public class ProductItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}