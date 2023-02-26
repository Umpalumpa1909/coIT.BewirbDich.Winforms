using coIT.BewirbDich.Winforms.Domain.Entities;

namespace coIT.BewirbDich.Winforms.Application.Repository;

public interface IRepository
{
    VersicherungsKonditionen? Find(Guid id);

    List<VersicherungsKonditionen> List();

    void Add(VersicherungsKonditionen dokument);

    void Save();

    void Delete(VersicherungsKonditionen dokument);
}