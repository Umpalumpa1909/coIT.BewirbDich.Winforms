using coIT.BewirbDich.Persistence.Constants;
using coIT.BewirbDich.Winforms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coIT.BewirbDich.Persistence.Configurations;

internal sealed class VersicherungsVorgangConfiguration : IEntityTypeConfiguration<VersicherungsVorgang>
{
    public void Configure(EntityTypeBuilder<VersicherungsVorgang> builder)
    {
        builder.HasKey(x => new { x.Id });
        builder.ToTable(TableNames.VersicherungsVorgang);
        builder.HasOne(x => x.VersicherungsKonditionen).WithOne().HasForeignKey<VersicherungsKonditionen>(x => x.Id);
        builder.HasOne(x => x.Angebotsanfrage).WithOne().HasForeignKey<Angebotsanfrage>(x => x.Id);
        builder.HasOne(x => x.Versicherungsschein).WithOne().HasForeignKey<Versicherungsschein>(x => x.Id);
    }
}