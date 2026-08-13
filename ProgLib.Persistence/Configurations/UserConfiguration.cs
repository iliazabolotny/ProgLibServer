using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgLib.Persistence.Entitites;

namespace ProgLib.Persistence.Configurations
{
        public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
        {
            public void Configure(EntityTypeBuilder<UserEntity> builder)
            {
                builder.HasKey(x => x.Id);

                builder.Property(u => u.Email).IsRequired();

                builder.Property(u => u.PasswordHash).IsRequired();

                builder.Property(u => u.UserName).IsRequired();
            }
        }
}
