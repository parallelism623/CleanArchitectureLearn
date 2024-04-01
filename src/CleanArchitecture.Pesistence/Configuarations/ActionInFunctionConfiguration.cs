using CleanArchitecture.Domain.Entities.Identity;
using CleanArchitecture.Pesistence.Constrants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Pesistence.Configuarations
{
    public class ActionInFunctionConfiguration : IEntityTypeConfiguration<ActionInFunction>
    {
        public void Configure(EntityTypeBuilder<ActionInFunction> builder)
        {
            builder.ToTable(TableNames.ActionInFunctions);
            builder.HasKey(x => new {x.ActionId, x.FunctionId});
        }
    }
}
