using Core.Models;

namespace ServerAPI.Repositories;

public interface IItemRepository
{
    Item[] GetAll();
    Item? GetById(int id);
    void Add(Item item);
    void Update(Item item);
    void DeleteById(int id);
}
