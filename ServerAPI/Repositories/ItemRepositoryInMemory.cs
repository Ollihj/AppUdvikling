using Core.Models;
using System.Linq;

namespace ServerAPI.Repositories;

public class ItemRepositoryInMemory : IItemRepository
{
    private List<Item> mItems = new();

    // ✅ Aligned
    public List<Item> GetAll() => mItems;

    // ✅ Aligned
    public Item Add(Item item)
    {
        item.Id = Random.Shared.Next();
        mItems.Add(item);
        return item;
    }

    // ✅ Required by interface
    public Item Toggle(int id)
    {
        var item = mItems.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.ErLedig = !item.ErLedig; // use the same property as DB repo
        }
        return item!;
    }

    // ✅ Aligned
    public void DeleteById(int id)
        => mItems.RemoveAll(i => i.Id == id);

    // Optional helper methods (allowed)
    public Item? GetById(int id)
        => mItems.FirstOrDefault(i => i.Id == id);

    public void Update(Item item)
    {
        var existing = mItems.FirstOrDefault(i => i.Id == item.Id);
        if (existing is not null)
            existing.Type = item.Type;
    }
}