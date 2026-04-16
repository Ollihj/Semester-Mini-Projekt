using Core.Models;

namespace BlazorApp4.Service;

public interface IItemService
{
    Task<List<annoncer>> GetAll();
    Task<annoncer?> GetById(string id);
    Task Add(annoncer item);
    Task Update(annoncer item);
    Task DeleteById(string id);
}