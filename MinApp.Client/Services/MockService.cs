using MinApp.Core.Interfaces;
using MinApp.Core.Models;

namespace MinApp.Client.Services;

public class MockService : IService
{
    private readonly List<Item> _items = new()
    {
        new Item { Id = 1, Name = "Testitem A" },
        new Item { Id = 2, Name = "Testitem B" },
        new Item { Id = 3, Name = "Testitem C" },
    };

    private int _nextId = 4;

    public Task<IEnumerable<Item>> GetAllAsync()
        => Task.FromResult<IEnumerable<Item>>(_items);

    public Task<Item?> GetByIdAsync(int id)
        => Task.FromResult(_items.FirstOrDefault(i => i.Id == id));

    public Task<Item> CreateAsync(Item item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return Task.FromResult(item);
    }

    public Task<Item?> UpdateAsync(int id, Item item)
    {
        var existing = _items.FirstOrDefault(i => i.Id == id);
        if (existing is null) return Task.FromResult<Item?>(null);
        existing.Name = item.Name;
        return Task.FromResult<Item?>(existing);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var existing = _items.FirstOrDefault(i => i.Id == id);
        if (existing is null) return Task.FromResult(false);
        _items.Remove(existing);
        return Task.FromResult(true);
    }
}
