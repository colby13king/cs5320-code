using LicenseAssetManager.Data;
using LicenseAssetManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

// 7.1.5
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
 * The builder.Services property is used to setup objects, known as services, that can be used throughout the application and that are accessed
 * through a feature called dependency injection.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
*/

// 7.1.5
// sets up the shared objects required by applications using the MVC framework and the Razor view engine.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionStrings:LicenseAssetManagerConnection"]));

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

// 7.1.5
var app = builder.Build();

// Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
*/

// 7.1.5
// enables support for serving static content from the wwwroot folder and will be created later
app.UseStaticFiles();

// 7.4.2
// Create URLs that are more appealing by creating a scheme that follows the pattern of composable URLs (makes sense to the user)
app.MapControllerRoute("pagination", "Products/Page{productPage}", new { controller = "Home", Action = "Index" });

// 7.1.5
// registers the MVC framework as a source of endpoints using a default convention for mapping requests to classes and methods
app.MapDefaultControllerRoute();

/*
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
*/

// 7.2.7
SeedData.EnsurePopulated(app);

// 7.1.5
app.Run();
