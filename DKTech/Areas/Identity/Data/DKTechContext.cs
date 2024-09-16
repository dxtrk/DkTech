using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DKTech.Models;


namespace DKTech.Areas.Identity.Data;

public class DKTechContext : IdentityDbContext<IdentityUser>
{
    public DKTechContext(DbContextOptions<DKTechContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "2", Name = "Staff", NormalizedName = "STAFF" }
            );

        var hasher = new PasswordHasher<IdentityUser>();
        builder.Entity<IdentityUser>().HasData(

            new IdentityUser
            {
                Id = "1",
                UserName = "admin123@gmail.com",
                NormalizedUserName = "ADMIN123@GMAIL.COM",
                Email = "admin123@gmail.com",
                NormalizedEmail = "ADMIN123@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin123")
            },
            new IdentityUser
            {
                Id = "2",
                UserName = "employee123@gmail.com",
                NormalizedUserName = "EMPLOYEE123@GMAIL.COM",
                Email = "employee123@gmail.com",
                NormalizedEmail = "EMPLOYEE123@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Employee123")
            }

        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = "1", UserId = "1" },
            new IdentityUserRole<string> { RoleId = "2", UserId = "2"}
    );

            }
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

  

public DbSet<DKTech.Models.Department> Department { get; set; } = default!;

public DbSet<DKTech.Models.Product> Product { get; set; } = default!;
    public DbSet<DKTech.Models.Order> Order { get; set; } = default!;
    public DbSet<DKTech.Models.Cart> Cart { get; set; } = default!;

public DbSet<DKTech.Models.Customer> Customer { get; set; } = default!;

public DbSet<DKTech.Models.Payment> Payment { get; set; } = default!;


}
 