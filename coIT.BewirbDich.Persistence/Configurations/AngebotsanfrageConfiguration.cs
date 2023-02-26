using coIT.BewirbDich.Domain.Entities;
using coIT.BewirbDich.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coIT.BewirbDich.Persistence.Configurations;

internal sealed class BerechungsParameterConfiguration : IEntityTypeConfiguration<BerechungsParameter>
{
    public void Configure(EntityTypeBuilder<BerechungsParameter> builder)
    {
        builder.ToTable(TableNames.BerechnungsParameter);
        builder.HasKey(x => new { x.Id });
    }
}