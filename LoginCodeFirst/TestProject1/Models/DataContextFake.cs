using Microsoft.EntityFrameworkCore;

namespace TestProject1.Models
{
    public class DataContextFake : DbContext
    {
        public DataContextFake(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<UserFake> UserFakes { get; set; } 
    }
}
    