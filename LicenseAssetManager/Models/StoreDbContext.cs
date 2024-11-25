using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace LicenseAssetManager.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options) 
        {
        
        }

        public DbSet<Product> Products => Set<Product>();

        public DbSet<Order> Orders => Set<Order>();
    }
}
