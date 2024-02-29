using FAIT.Domain.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FAIT.Persistence.Configurations.User;

public class AppUserConfig: IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(fs => fs.FirstName).HasMaxLength(127).IsRequired();
        builder.Property(ls => ls.LastName).HasMaxLength(127).IsRequired();
        builder.Property(nk => nk.NickName).HasMaxLength(127);
        builder.Property(img => img.Image).HasMaxLength(511);
        builder.Property(bio => bio.Bio).HasMaxLength(511);
        
    }
}