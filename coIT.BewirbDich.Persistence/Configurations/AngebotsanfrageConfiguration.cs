using coIT.BewirbDich.Persistence.Constants;
using coIT.BewirbDich.Winforms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coIT.BewirbDich.Persistence.Configurations;

internal sealed class AngebotsanfrageConfiguration : IEntityTypeConfiguration<Angebotsanfrage>
{
    public void Configure(EntityTypeBuilder<Angebotsanfrage> builder)
    {
        builder.ToTable(TableNames.Angebotsanfrage);
        builder.HasKey(x => new { x.Id });
    }
}