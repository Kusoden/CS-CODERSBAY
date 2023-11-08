using Microsoft.EntityFrameworkCore;

namespace _1_Person_management
{
    public class LINQDatabase : DbContext
    {
        public DbSet<Household> Households { get; set; }

        public LINQDatabase(DbContextOptions<LINQDatabase> options) : base(options)
        {
        }
    }
}