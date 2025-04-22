using CRUD.Infrastructure;
using CRUD.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add services BEFORE builder.Build()

builder.Services.AddControllersWithViews();

// Register DataContext
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); // or use "DbConnection" if needed
});

// Register ApplicationDbContext if it's used separately
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Session + Caching
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Was IOTimeout (should be IdleTimeout)
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Optional: Identity
// builder.Services.AddIdentity<AppUser, IdentityRole>()
//     .AddEntityFrameworkStores<DataContext>()
//     .AddDefaultTokenProviders();

// ✅ Build the app
var app = builder.Build();

// ✅ Use session and middleware
app.UseSession();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Routes
app.MapControllerRoute(
    name: "Areas",
    pattern: "{area:exists}/{controller=Products}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "products",
    pattern: "/products/{categorySlug?}",
    defaults: new { controller = "Products", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// ✅ Seed the database (after services are built)
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<DataContext>();
    SeedData.SeedDatabase(context);
}

app.Run();
