using KeyService.Persistance.Data;
using Microsoft.EntityFrameworkCore;

namespace KeyService.Persistance
{
    public class KeyDatabaseContext : DbContext
    {
        public KeyDatabaseContext(DbContextOptions<KeyDatabaseContext> options)
            : base(options)
        {
        }
        public DbSet<KeyData> Keys { get; set; }

    }

}
