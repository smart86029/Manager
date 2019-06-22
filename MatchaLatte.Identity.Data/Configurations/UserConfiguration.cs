using MatchaLatte.Identity.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MatchaLatte.Identity.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(32);

            builder
                .HasIndex(u => u.UserName)
                .IsUnique();

            builder.Metadata
                .FindNavigation(nameof(User.UserRoles))
                .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasData(GetSeedData());
        }

        private User[] GetSeedData()
        {
            var result = new User[]
            {
                new User("Admin", "123fff", true)
            };

            return result;
        }
    }
}