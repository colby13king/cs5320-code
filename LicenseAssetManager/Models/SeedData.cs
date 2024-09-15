using Microsoft.EntityFrameworkCore;

namespace LicenseAssetManager.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            StoreDbContext context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) 
            {
                context.Database.Migrate();
            }

            if(!context.Products.Any()) 
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "BestCAD",
                        Description = "The worlds best CAD application",
                        Category = "Engineering Tools",
                        Price = 5000
                    },
                    new Product
                    {
                        Name = "BestCAD_XL",
                        Description = "The XL features for BestCAD",
                        Category = "Engineering Tools",
                        Price = 100000
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
