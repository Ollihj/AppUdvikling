using System.Net.Http.Json;
using MinApp.Core.Interfaces;
using MinApp.Core.Models;

namespace MinApp.Client.Services;

public class ProductionService : IService
{
    private readonly HttpClient _http;

    public ProductionService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<Item>> GetAllAsync()
        => await _http.GetFromJsonAsync<IEnumerable<Item>>("api/items") ?? Enumerable.Empty<Item>();

    public async Task<Item?> GetByIdAsync(int id)
        => await _http.GetFromJsonAsync<Item>($"api/items/{id}");

    public async Task<Item> CreateAsync(Item item)
    {
        var response = await _http.PostAsJsonAsync("api/items", item);
        response.EnsureSuccessStatusCode();
        return (await response.Content.ReadFromJsonAsync<Item>())!;
    }

    public async Task<Item?> UpdateAsync(int id, Item item)
    {
        var response = await _http.PutAsJsonAsync($"api/items/{id}", item);
        if (!response.IsSuccessStatusCode) return null;
        return await response.Content.ReadFromJsonAsync<Item>();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/items/{id}");
        return response.IsSuccessStatusCode;
    }
}
