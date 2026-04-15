using Core.Models;

namespace ServerAPI.Repositories;

public interface IBrugerRepository
{
    List<bruger> GetAll();
    bruger? GetById(string id);
    void Add(bruger bruger);
    void Update(bruger bruger);
    void Delete(string id);
}
