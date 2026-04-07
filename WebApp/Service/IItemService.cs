using Core.Models;

namespace WebApp.Service;

public interface IItemService
{
    Task<List<Item>> GetAll();
    Task<Item?> GetById(int id);
    Task Add(Item item);
    Task Update(Item item);
    Task DeleteById(int id);
}
