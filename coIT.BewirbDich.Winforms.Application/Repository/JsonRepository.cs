using coIT.BewirbDich.Winforms.Domain.Entities;
using System.Text;
using System.Text.Json;

namespace coIT.BewirbDich.Winforms.Application.Repository;

public class JsonRepository : IRepository
{
    private readonly string _file;
    private List<VersicherungsKonditionen> _dokumente;

    public JsonRepository(string file)
    {
        _file = file;
        Load();
    }

    private void Load()
    {
        if (!File.Exists(_file))
        {
            var empty = Enumerable.Empty<VersicherungsKonditionen>();
            File.WriteAllText(_file, JsonSerializer.Serialize(empty), Encoding.UTF8);
        }

        var json = File.ReadAllText(_file, Encoding.UTF8);
        _dokumente = JsonSerializer.Deserialize<List<VersicherungsKonditionen>>(json) ?? new List<VersicherungsKonditionen>();
    }

    public VersicherungsKonditionen? Find(Guid id)
    {
        return _dokumente.SingleOrDefault(dok => dok.Id == id);
    }

    public List<VersicherungsKonditionen> List()
    {
        return _dokumente;
    }

    public void Add(VersicherungsKonditionen dokument)
    {
        _dokumente.Add(dokument);
    }

    public void Delete(VersicherungsKonditionen dokument)
    {
        _dokumente.Remove(dokument);
    }

    public void Save()
    {
        var json = JsonSerializer.Serialize(_dokumente);
        File.WriteAllText(_file, json, new UTF8Encoding());
    }
}