using AppDevGCD1104.Models;
using Microsoft.EntityFrameworkCore;

namespace AppDevGCD1104.Data
{
    public class ApplicationDBContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public ApplicationDBContext(DbContextOptions options):base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1,Name = "Adventure", Description="So funny"},
                new Category { Id = 2, Name = "Roman", Description = "So romantic" },
                new Category { Id = 3, Name = "Horror", Description = "So scary" },
                new Category { Id = 4, Name = "Science", Description = "So Boring" }
               );

        }
    }
}
