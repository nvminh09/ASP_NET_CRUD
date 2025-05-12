using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRUD.Models;


namespace CRUD.Infrastructure
{
    public class DataContext : IdentityDbContext<AppUser>

    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {     
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
