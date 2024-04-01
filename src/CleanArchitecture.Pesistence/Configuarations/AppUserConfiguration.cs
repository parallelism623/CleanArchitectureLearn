using CleanArchitecture.Domain.Entities.Identity;
using CleanArchitecture.Pesistence.Constrants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Pesistence.Configuarations
{
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable(TableNames.AppUsers);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.IsDirector).HasDefaultValue(false);
            builder.Property(x => x.IsHeadOfDepartment).HasDefaultValue(false);
            builder.Property(x => x.ManagerId).HasDefaultValue(null);
            builder.Property(x => x.IsReceipient).HasDefaultValue(-1);

          
            builder.HasMany(e => e.Claims)
                .WithOne()
                .HasForeignKey(uc => uc.UserId)
                .IsRequired();

      
            builder.HasMany(e => e.Logins)
                .WithOne()
                .HasForeignKey(ul => ul.UserId)
                .IsRequired();

            
            builder.HasMany(e => e.Tokens)
                .WithOne()
                .HasForeignKey(ut => ut.UserId)
                .IsRequired();

          
            builder.HasMany(e => e.UserRoles)
                .WithOne()
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
        }
    }
}
