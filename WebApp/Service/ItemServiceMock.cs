using Core.Models;

namespace WebApp.Service;

public class ItemServiceMock : IItemService
{
    private List<Item> mItems = new();

    public async Task<List<Item>> GetAll() => mItems;

    public async Task<Item?> GetById(int id) => mItems.FirstOrDefault(i => i.Id == id);

    public async Task Add(Item item)
    {
        item.Id = Random.Shared.Next();
        mItems.Add(item);
    }

    public async Task Update(Item item)
    {
        var existing = mItems.FirstOrDefault(i => i.Id == item.Id);
        if (existing is not null) existing.Type = item.Type;
    }

    public async Task DeleteById(int id) => mItems.RemoveAll(i => i.Id == id);
}
