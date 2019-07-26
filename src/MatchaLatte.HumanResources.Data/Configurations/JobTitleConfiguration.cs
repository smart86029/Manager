using MatchaLatte.HumanResources.Domain.JobTitles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.HumanResources.Data.Configurations
{
    public class JobTitleConfiguration : IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder
               .Property(j => j.Name)
               .IsRequired()
               .HasMaxLength(32);
        }
    }
}