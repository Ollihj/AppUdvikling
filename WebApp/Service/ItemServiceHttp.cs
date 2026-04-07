using System.Net.Http.Json;
using Core.Models;
using WebApp.Pages;

namespace WebApp.Service;

public class ItemServiceHttp : IItemService
{
    private HttpClient client;

    public ItemServiceHttp(HttpClient client)
    {
        this.client = client;
    }

    public async Task<List<Item>> GetAll()
    {
        var data = await client.GetFromJsonAsync<List<Item>>($"{Config.ServerUrl}/api/items");
        return data ?? new List<Item>();
    }

    public async Task<Item?> GetById(int id)
    {
        return await client.GetFromJsonAsync<Item>($"{Config.ServerUrl}/api/items/{id}");
    }

    public async Task Add(Item item)
    {
        await client.PostAsJsonAsync($"{Config.ServerUrl}/api/items", item);
    }

    public async Task Update(Item item)
    {
        await client.PutAsJsonAsync($"{Config.ServerUrl}/api/items/{item.Id}", item);
    }

    public async Task DeleteById(int id)
    {
        await client.DeleteAsync($"{Config.ServerUrl}/api/items/delete?id={id}");
    }
}
