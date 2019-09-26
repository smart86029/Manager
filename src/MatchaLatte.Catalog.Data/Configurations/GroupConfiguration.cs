using MatchaLatte.Catalog.Domain.Groups;
using MatchaLatte.Common.EntityFramework.Configurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Catalog.Data.Configurations
{
    public class GroupConfiguration : EntityConfiguration<Group>
    {
        public override void Configure(EntityTypeBuilder<Group> builder)
        {
            builder
                .Property(g => g.Remark)
                .HasMaxLength(512);
        }
    }
}