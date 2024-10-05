using Microsoft.EntityFrameworkCore;

// to reset the database run this command
// dotnet ef database drop --project LicenseAssetManager --force --context StoreDbContext
// note that the name of the context is found in the Program.cs file

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
                        Price = 1
                    },
                    new Product
                    {
                        Name = "BestCAD_Sch",
                        Description = "BestCAD Schematic Editor",
                        Category = "Engineering Tools",
                        Price = 1
                    },
                    new Product
                    {
                        Name = "BestCAD_Layout",
                        Description = "BestCAD Layout Editor",
                        Category = "Engineering Tools",
                        Price = 1
                    },
                    new Product
                    {
                        Name = "BestCAD_XL",
                        Description = "The XL features for BestCAD",
                        Category = "Engineering Tools",
                        Price = 14
                    },
                    new Product
                    {
                        Name = "WordNotPerfect",
                        Description = "A Text Editor without Checks",
                        Category = "Text Editors",
                        Price = 1
                    },
                    new Product
                    {
                        Name = "WordNotPerfect_SpellCheck",
                        Description = "Add Spell Check to WordNotPerfect",
                        Category = "Text Editors",
                        Price = 1
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
