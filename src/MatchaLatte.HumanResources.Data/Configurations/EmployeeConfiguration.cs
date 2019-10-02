using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.HumanResources.Domain.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class EmployeeConfiguration : EntityConfiguration<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
        }
    }
}