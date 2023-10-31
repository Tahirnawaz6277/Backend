using KeepNotice.Models.Domin;
using Microsoft.EntityFrameworkCore;

namespace KeepNotice.Data
{
    public class DbContextClass : DbContext
    {

        public DbContextClass(DbContextOptions options) : base(options)
        {

        }


        public DbSet<Tasks> tasks { get; set; }

      
    }
}
