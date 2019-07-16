﻿using MatchaLatte.Catalog.Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class ProductItemConfiguration : IEntityTypeConfiguration<ProductItem>
    {
        public void Configure(EntityTypeBuilder<ProductItem> builder)
        {
            builder
                .Property(i => i.Name)
                .HasMaxLength(32);

            builder
                .Property(i => i.Price)
                .HasColumnType("decimal(19, 4)");

            builder
                .HasOne(i => i.Product)
                .WithMany(p => p.ProductItems)
                .HasForeignKey(i => i.ProductId);
        }
    }
}