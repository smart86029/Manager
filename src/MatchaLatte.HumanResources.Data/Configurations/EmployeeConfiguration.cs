using MatchaLatte.HumanResources.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Metadata
                .FindNavigation(nameof(Employee.JobChanges))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}