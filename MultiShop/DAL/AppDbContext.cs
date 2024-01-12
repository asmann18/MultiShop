using Microsoft.EntityFrameworkCore;
using MultiShop.Models;

namespace MultiShop.DAL;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt)
    {
        
    }
    public DbSet<Slider> Sliders { get; set; } = null!; 
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<Product> Products{ get; set; } = null!;
    public DbSet<Category> Categories{ get; set; } = null!;
    public DbSet<Size> Sizes{ get; set; } = null!;
    public DbSet<ProductSize> ProductSizes{ get; set; } = null!;
    
}
