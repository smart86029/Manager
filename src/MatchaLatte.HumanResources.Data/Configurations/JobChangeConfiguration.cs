using MatchaLatte.HumanResources.Domain.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class JobChangeConfiguration : IEntityTypeConfiguration<JobChange>
    {
        public void Configure(EntityTypeBuilder<JobChange> builder)
        {
            builder.HasIndex(j => j.DepartmentId);

            builder.HasIndex(j => j.JobTitleId);
        }
    }
}