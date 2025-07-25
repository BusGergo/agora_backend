using agora_shop.Models;
using Microsoft.EntityFrameworkCore;
namespace agora_shop.Data;

public class AppDbContext :  DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    
    public DbSet<Product> Products { get; set; }
}