using CqrsMediatrProject.Models;
using Microsoft.EntityFrameworkCore;

namespace CqrsMediatrProject;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions options) : base(options)
    {
        
    }
    
    public DbSet<Product> Products { get; set; }
}