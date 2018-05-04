using Manager.Models.GroupBuying;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Manager.Data.EntityFramework.Configurations
{
    public class GroupStoreConfiguration : IEntityTypeConfiguration<GroupStore>
    {
        public void Configure(EntityTypeBuilder<GroupStore> builder)
        {
            builder.ToTable("GroupStore", "GroupBuying");
            builder.HasKey(x => new { x.GroupId, x.StoreId });
            builder.HasData(GetSeedData());
        }

        private GroupStore[] GetSeedData()
        {
            var result = new GroupStore[]
            {
            };

            return result;
        }
    }
}