using ApiDers.Core.Entities;
using APIDers1.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APIDers1.Data.Context
{
    public class AppDbContext : IdentityDbContext
    {
        public DbSet<Category>Categories { get; set; }
        public DbSet<Product> Products { get; set; } 
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        
    }
}
