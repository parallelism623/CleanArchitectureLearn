
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Pesistence.Configuarations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Domain.Entities.Identity.Action>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Identity.Action> builder)
        {

        }
    }
}
