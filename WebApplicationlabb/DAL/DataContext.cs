using Microsoft.EntityFrameworkCore;
using WebApplicationlabb.DAL.Models;

namespace WebApplicationlabb.DAL
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany<Course>(u => u.Courses)
                .WithMany(c => c.Users)
                .UsingEntity(x => x.ToTable("UserCourse"));

        }
    }
}
