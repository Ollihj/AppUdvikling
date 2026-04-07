using Core.Models;

namespace ServerAPI.Repositories;

public class ItemRepositoryDb : IItemRepository
{
    public Item[] GetAll() => throw new NotImplementedException();
    public Item? GetById(int id) => throw new NotImplementedException();
    public void Add(Item item) => throw new NotImplementedException();
    public void Update(Item item) => throw new NotImplementedException();
    public void DeleteById(int id) => throw new NotImplementedException();
}
