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
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<DKTech.Models.Department> Department { get; set; } = default!;

public DbSet<DKTech.Models.Product> Product { get; set; } = default!;
    public DbSet<DKTech.Models.Order> Order { get; set; } = default!;
    public DbSet<DKTech.Models.Cart> Cart { get; set; } = default!;

public DbSet<DKTech.Models.Customer> Customer { get; set; } = default!;

public DbSet<DKTech.Models.Payment> Payment { get; set; } = default!;


}
 