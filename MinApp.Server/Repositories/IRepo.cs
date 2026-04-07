using MinApp.Core.Models;

namespace MinApp.Server.Repositories;

public interface IRepo
{
    Item[] GetAll();
    Item? GetById(int id);
    void Add(Item item);
    void Update(Item item);
    void DeleteById(int id);
}
