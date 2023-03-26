using Microsoft.EntityFrameworkCore;
using StudentRestAPI.Models;

namespace StudentRestAPI.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
