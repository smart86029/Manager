﻿using Manager.Domain.Models.System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.System
{
    public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
    {
        public void Configure(EntityTypeBuilder<RolePermission> builder)
        {
            builder.ToTable("RolePermission", "System");
            builder.HasKey(x => new { x.RoleId, x.PermissionId });
            builder.HasData(GetSeedData());
        }

        private RolePermission[] GetSeedData()
        {
            var result = new RolePermission[]
            {
            };

            return result;
        }
    }
}