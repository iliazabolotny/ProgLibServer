using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProgLib.Persistence.Entitites;

namespace ProgLib.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.Title).IsRequired();

            builder.Property(b => b.Description).IsRequired();

            builder.Property(b => b.Price).IsRequired();
        }
    }
}
