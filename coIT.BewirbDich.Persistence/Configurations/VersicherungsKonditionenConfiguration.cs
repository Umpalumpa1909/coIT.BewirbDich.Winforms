using coIT.BewirbDich.Persistence.Constants;
using coIT.BewirbDich.Winforms.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace coIT.BewirbDich.Persistence.Configurations;

internal sealed class VersicherungsKonditionenConfiguration : IEntityTypeConfiguration<VersicherungsKonditionen>
{
    public void Configure(EntityTypeBuilder<VersicherungsKonditionen> builder)
    {
        builder.ToTable(TableNames.VersicherungsKondidtionen);
        builder.HasKey(x => new { x.Id });
    }
}