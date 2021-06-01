using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        
        //Dbset will use our POCO class to create a table in the database
        public DbSet<AppUser> Users { get; set; }
    }
}