using Microsoft.EntityFrameworkCore;

namespace Repository.Entity
{
    public class SampleApiDbContext : DbContext
    {
        public SampleApiDbContext() { }
        public SampleApiDbContext(DbContextOptions<SampleApiDbContext> options) :
            base(options)
        {

        }

        public virtual DbSet<OrderEntity> Orders { get; set; } = null!;
    }
}
