using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable("Group", "GroupBuying");
            builder.Property(g => g.Remark)
                .HasMaxLength(512);
            builder.HasOne(g => g.Creator)
                .WithMany()
                .HasForeignKey(s => s.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasData(GetSeedData());
        }

        private Group[] GetSeedData()
        {
            var result = new Group[]
            {
            };

            return result;
        }
    }
}