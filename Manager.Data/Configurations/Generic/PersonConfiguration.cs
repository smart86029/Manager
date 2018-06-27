using System;
using Manager.Domain.Models.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.Configurations.Generic
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(32);
            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(32);
            builder.HasData(GetSeedData());
        }

        private Person[] GetSeedData()
        {
            var result = new Person[]
            {
                new Person { BusinessEntityId = 1, FirstName = "管理員", LastName = "超級", Gender = Gender.NotApplicable, BirthDate = DateTime.Parse("1990-01-01") }
            };

            return result;
        }
    }
}