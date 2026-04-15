using Core.Models;

namespace ServerAPI.Repositories;

public interface IKøbsanmodningRepository
{
    List<købsanmodninger> GetAll();
    købsanmodninger? GetById(string id);
    void Add(købsanmodninger købsanmodning);
    void Update(købsanmodninger købsanmodning);
    void Delete(string id);
}
