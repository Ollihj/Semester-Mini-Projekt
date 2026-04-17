using Core.Models;

namespace BlazorApp4.Service;

public interface IKøbsanmodningerService
{
    Task<List<købsanmodninger>> GetAll();
    Task<købsanmodninger?> GetById(string id);
    Task Add(købsanmodninger anmodning);
    Task Update(købsanmodninger anmodning);
    Task DeleteById(string id);
}