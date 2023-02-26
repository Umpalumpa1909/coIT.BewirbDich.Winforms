using coIT.BewirbDich.Winforms.Domain.Primitives;

namespace coIT.BewirbDich.Winforms.Domain.Entities;

public class Versicherungsschein : Entity
{
    public DateTime ErstellungsDatum { get; private set; }

    public int Versicherungsnummer { get; private set; }

    public Versicherungsschein(Guid id)
        : base(id)
    {
        ErstellungsDatum = DateTime.Now;
    }
}