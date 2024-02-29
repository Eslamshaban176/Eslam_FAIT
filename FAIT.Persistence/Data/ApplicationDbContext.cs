using FAIT.Domain.User;
using FAIT.Persistence.Configurations.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FAIT.Persistence.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
{
    public  DbSet<AppUser> Users { get; set; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       new AppUserConfig().Configure(modelBuilder.Entity<AppUser>());
       
       base.OnModelCreating(modelBuilder);
    }
}