﻿using Manager.Common;
using Manager.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User", "System");
            builder.Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasIndex(u => u.UserName)
                .IsUnique();
            builder.HasData(GetSeedData());
        }

        private User[] GetSeedData()
        {
            var result = new User[]
            {
                new User(1, "Admin", CryptographyUtility.Hash("123fff"), true, 1)
            };

            return result;
        }
    }
}