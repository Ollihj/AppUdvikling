using MinApp.Core.Models;

namespace MinApp.Client.Services;

public interface IService
{
    Task<List<Item>> GetAll();
    Task<Item?> GetById(int id);
    Task Add(Item item);
    Task Update(Item item);
    Task DeleteById(int id);
}
