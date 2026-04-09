using Core.Models;

namespace ServerAPI.Repositories;

public interface IItemRepository
{

    List<Item> GetAll();
    Item Add(Item item);
    Item Toggle(int id);
    void DeleteById(int id);

}
