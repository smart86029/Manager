﻿using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(GetSeedData());
        }

        private UserRole[] GetSeedData()
        {
            var result = new UserRole[]
            {
            };

            return result;
        }
    }
}