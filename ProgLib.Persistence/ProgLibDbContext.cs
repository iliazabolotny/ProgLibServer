using Microsoft.EntityFrameworkCore;
using ProgLib.Persistence.Entitites;

namespace ProgLib.Persistence
{
    public class ProgLibDbContext: DbContext
    {
        public ProgLibDbContext(DbContextOptions<ProgLibDbContext> options) : base(options)
        {

        }

        public DbSet<BookEntity> Books { get; set; }

        public DbSet<UserEntity> Users { get; set; }
    }
}
