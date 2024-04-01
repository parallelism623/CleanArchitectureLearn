using CleanArchitecture.Pesistence.Constrants;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Entities.Identity;


namespace CleanArchitecture.Pesistence.Configuarations
{
    internal sealed class FunctionConfiguration : IEntityTypeConfiguration<Function>
    {
        public void Configure(EntityTypeBuilder<Function> builder)
        {
            builder.ToTable(TableNames.Functions);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.ParrentId)
                .HasMaxLength(50)
                .HasDefaultValue(null);
            builder.Property(x => x.CssClass).HasMaxLength(50).HasDefaultValue(null);
            builder.Property(x => x.Url).HasMaxLength(50).IsRequired(true);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.SortOrder).HasDefaultValue(null);

  
            builder.HasMany(e => e.Permissions)
                .WithOne()
                .HasForeignKey(p => p.FunctionId)
                .IsRequired();

         
            builder.HasMany(e => e.ActionInFunctions)
                .WithOne()
                .HasForeignKey(aif => aif.FunctionId)
                .IsRequired();
        }
    }
}
