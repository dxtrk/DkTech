using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DKTech.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using DKTech.Models;
using NuGet.DependencyResolver;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Connection") ?? throw new InvalidOperationException("Connection string 'Connection' not found.");

builder.Services.AddDbContext<DKTechContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultTokenProviders()
    .AddRoles<IdentityRole>()

    .AddEntityFrameworkStores<DKTechContext>();
        
        
        
        



// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DKTechContext>();
    context.Database.Migrate();
    // requires using Microsoft.Extensions.Configuration;
    // Set password with the Secret Manager tool.
    // dotnet user-secrets set SeedUserPW <pw>

    var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");

   
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
using (var scope = app.Services.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//    var roles = new[] { "Admin", "Manager", "User" };

//    foreach (var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//            await roleManager.CreateAsync(new IdentityRole(role));
//    }
//}
//using (var scope = app.Services.CreateScope())
//{
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

//    string FirstName = "Dexter";
//    string LastName = "Ku";
//    DateTime DateOfBirth = new DateTime(2000, 1, 1);
//    string email = "dexterku@gmail.com";
//    string password = "Sweethome49";

//    if (await userManager.FindByEmailAsync(email) == null)
//    {
//        var user = new User();
   
//        user.Email = email;
//        user.FirstName = FirstName;
//        user.LastName = LastName;
     

//        await userManager.CreateAsync(user, password);

//        await userManager.AddToRoleAsync(user, "Admin");
//        await userManager.AddToRoleAsync(user, "Employee");
//        await userManager.AddToRoleAsync(user, "Customer");
//    }

//}
app.Run();
