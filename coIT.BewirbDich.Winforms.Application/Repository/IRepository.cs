using coIT.BewirbDich.Domain.Entities;

namespace coIT.BewirbDich.Application.Repository;

public interface IRepository
{
    void Add(VersicherungsKonditionen dokument);

    void Delete(VersicherungsKonditionen dokument);

    VersicherungsKonditionen? Find(Guid id);

    List<VersicherungsKonditionen> List();

    void Save();
}