using Core.Models;

namespace ServerAPI.Repositories;

public class ItemRepositoryInMemory : IItemRepository
{
    private List<Item> mItems = new();

    public Item[] GetAll() => mItems.ToArray();

    public Item? GetById(int id) => mItems.FirstOrDefault(i => i.Id == id);

    public void Add(Item item)
    {
        item.Id = Random.Shared.Next();
        mItems.Add(item);
    }

    public void Update(Item item)
    {
        var existing = mItems.FirstOrDefault(i => i.Id == item.Id);
        if (existing is not null) existing.Name = item.Name;
    }

    public void DeleteById(int id) => mItems.RemoveAll(i => i.Id == id);
}
