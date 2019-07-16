﻿using MatchaLatte.Catalog.Domain.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasOne(x => x.Store)
                .WithMany(s => s.ProductCategories)
                .HasForeignKey(x => x.StoreId);

            builder.Metadata
                .FindNavigation(nameof(ProductCategory.Products))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}