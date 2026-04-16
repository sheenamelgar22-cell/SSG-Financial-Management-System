using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetIdentityLab.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ ADD SERVICES FIRST (BEFORE BUILD)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") 
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = false) // 🔥 set to false for testing
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // ✅ ONLY ONCE, AND BEFORE BUILD

// ✅ BUILD APP
var app = builder.Build();

// ✅ MIDDLEWARE
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // ✅ IMPORTANT (fix for CSS/images)

app.UseRouting();

app.UseAuthentication(); // ✅ REQUIRED for Identity
app.UseAuthorization();

// ✅ ROUTES
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.MapRazorPages();

// ✅ REDIRECT ROOT → LOGIN
app.MapGet("/", context =>
{
    context.Response.Redirect("/Identity/Account/Login");
    return Task.CompletedTask;
});

app.Run();