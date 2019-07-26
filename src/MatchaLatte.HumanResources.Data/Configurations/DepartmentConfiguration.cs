using MatchaLatte.HumanResources.Domain.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder
                .Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(32);

            builder.HasIndex(d => d.ParentId);
        }
    }
}