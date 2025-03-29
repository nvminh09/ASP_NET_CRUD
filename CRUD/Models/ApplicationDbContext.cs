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
                new Customer { Id = 1, FirstName = "John", LastName = "Jones", Email = "john@gmail.com" },
                new Customer { Id = 2, FirstName = "Mary", LastName = "Jones", Email = "mary@gmail.com" },
                new Customer { Id = 3, FirstName = "Jack", LastName = "Smith", Email = "jack@gmail.com" }
            );
        }
    }
}