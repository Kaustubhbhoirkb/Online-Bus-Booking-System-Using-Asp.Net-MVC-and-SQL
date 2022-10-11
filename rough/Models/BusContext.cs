using Microsoft.EntityFrameworkCore;

namespace rough.Models
{
    public class BusContext : DbContext
    {
        public DbSet<Bus> addbus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=NSL-LTRG030\SQLEXPRESS19;Database=rough1;Integrated Security=True;");
            }
        }
    }
}
