using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DKTech.Models;

namespace DKTech.Areas.Identity.Data;

// Context class for ASP.NET Identity, inheriting from IdentityDbContext
public class DKTechContext : IdentityDbContext<IdentityUser>
{
    // Constructor accepting DbContext options
    public DKTechContext(DbContextOptions<DKTechContext> options)
        : base(options)
    {
    }

    // Configuring the model
    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Call the base method to ensure the default behavior is applied
        base.OnModelCreating(builder);

        // Configure composite key for IdentityUserLogin
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        // Seed initial roles into the IdentityRole table
        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Staff", NormalizedName = "STAFF" }
        );

        // Create a password hasher for hashing user passwords
        var hasher = new PasswordHasher<IdentityUser>();

        // Seed initial users into the IdentityUser table
        builder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "1",
                UserName = "admin123@gmail.com",
                NormalizedUserName = "ADMIN123@GMAIL.COM",
                Email = "admin123@gmail.com",
                NormalizedEmail = "ADMIN123@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123") // Hash password for admin user
            },
            new IdentityUser
            {
                Id = "2",
                UserName = "employee123@gmail.com",
                NormalizedUserName = "EMPLOYEE123@GMAIL.COM",
                Email = "employee123@gmail.com",
                NormalizedEmail = "EMPLOYEE123@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Employee123") // Hash password for employee user
            }
        );

        // Seed initial user-role mappings in the IdentityUserRole table
        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = "1", UserId = "1" }, // Admin role for admin user
            new IdentityUserRole<string> { RoleId = "2", UserId = "2" }  // Staff role for employee user
        );
    }

    // Define DbSet properties for application-specific models
    public DbSet<DKTech.Models.Department> Department { get; set; } = default!;
    public DbSet<DKTech.Models.Product> Product { get; set; } = default!;
    public DbSet<DKTech.Models.Order> Order { get; set; } = default!;
    public DbSet<DKTech.Models.Cart> Cart { get; set; } = default!;
    public DbSet<DKTech.Models.Customer> Customer { get; set; } = default!;
    public DbSet<DKTech.Models.Payment> Payment { get; set; } = default!;
}
