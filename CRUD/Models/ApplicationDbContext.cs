using Microsoft.EntityFrameworkCore;

namespace CRUD.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "John", LastName = "Jones", DateBirth = new DateOnly(1990, 1, 1), Phone = "0123456789", Email = "john@gmail.com" },
                new Customer { Id = 2, FirstName = "Mary", LastName = "Jones", DateBirth = new DateOnly(1990, 1, 1), Phone = "0123456789", Email = "mary@gmail.com" },
                new Customer { Id = 3, FirstName = "Jack", LastName = "Smith", DateBirth = new DateOnly(1990, 1, 1), Phone = "0123456789", Email = "jack@gmail.com" }
            );
        }
    }
}