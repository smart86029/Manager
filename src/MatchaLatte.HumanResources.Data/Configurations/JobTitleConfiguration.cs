using MatchaLatte.Common.EntityFramework.Configurations;
using MatchaLatte.HumanResources.Domain.JobTitles;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class JobTitleConfiguration : EntityConfiguration<JobTitle>
    {
        public override void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder
               .Property(j => j.Name)
               .IsRequired()
               .HasMaxLength(32);
        }
    }
}