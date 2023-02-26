using coIT.BewirbDich.Domain.Entities;
using coIT.BewirbDich.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coIT.BewirbDich.Persistence.Configurations;

internal sealed class VersicherungsscheinConfiguration : IEntityTypeConfiguration<Versicherungsschein>
{
    public void Configure(EntityTypeBuilder<Versicherungsschein> builder)
    {
        builder.ToTable(TableNames.Versicherungsschein);
        builder.Property(x => x.Versicherungsnummer).UseSequence();
        builder.HasKey(x => new { x.Id, x.Versicherungsnummer });
    }
}