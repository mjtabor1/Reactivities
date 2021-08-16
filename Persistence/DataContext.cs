using Microsoft.EntityFrameworkCore;
using Domain;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        //Represents a table in our DB "Activities". Properties inside this table
        //are based on the <Activity> class
        public DbSet<Activity> Activities { get; set; }
    }
}
