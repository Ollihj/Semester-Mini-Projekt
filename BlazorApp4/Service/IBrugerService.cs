using Core.Models;

namespace BlazorApp4.Service;

public interface IBrugerService
{
    Task<List<bruger>> GetAll();
    Task<bruger?> GetById(string id);
}
