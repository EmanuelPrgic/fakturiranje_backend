using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<AppUser> Users { get; set; }
    }
}