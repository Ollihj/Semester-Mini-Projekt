using Core.Models;

namespace ServerAPI.Repositories;

public interface IAnnonceRepository
{
    List<annoncer> GetAll();
    annoncer? GetById(string id);
    void Add(annoncer annonce);
    void Update(annoncer annonce);
    void Delete(string id);
}