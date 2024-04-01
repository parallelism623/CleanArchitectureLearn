
using CleanArchitecture.Pesistence.Constrants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Action = CleanArchitecture.Domain.Entities.Identity.Action;

namespace CleanArchitecture.Pesistence.Configuarations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Domain.Entities.Identity.Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasMany(act => act.Permissions)
                   .WithOne()
                   .HasForeignKey(per => per.ActionId)
                   .IsRequired();
            builder.HasMany(act => act.ActionInFunctions)
                   .WithOne()
                   .HasForeignKey(aif => aif.ActionId)
                   .IsRequired();
            builder.ToTable(TableNames.Actions);

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.IsActive).HasDefaultValue(true);
            builder.Property(x => x.SortOrder).HasDefaultValue(null);
        }
    }
}
//Permissions ActionInFunction