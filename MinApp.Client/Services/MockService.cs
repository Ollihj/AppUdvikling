using MinApp.Core.Models;

namespace MinApp.Client.Services;

public class MockService : IService
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
        if (existing is not null) existing.Name = item.Name;
    }

    public async Task DeleteById(int id) => mItems.RemoveAll(i => i.Id == id);
}
