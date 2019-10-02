using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.HumanResources.Domain.Employees;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class JobChangeConfiguration : EntityConfiguration<JobChange>
    {
        public override void Configure(EntityTypeBuilder<JobChange> builder)
        {
            builder.HasIndex(j => j.DepartmentId);

            builder.HasIndex(j => j.JobTitleId);
        }
    }
}