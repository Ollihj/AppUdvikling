using MinApp.Core.Interfaces;
using MinApp.Core.Models;

namespace MinApp.Server.Repositories;

// Stub til fremtidig databaseimplementering (fx EF Core)
public class DbRepo : IRepo
{
    public Task<IEnumerable<Item>> GetAllAsync()
        => throw new NotImplementedException("Erstat med EF Core DbContext");

    public Task<Item?> GetByIdAsync(int id)
        => throw new NotImplementedException("Erstat med EF Core DbContext");

    public Task<Item> CreateAsync(Item item)
        => throw new NotImplementedException("Erstat med EF Core DbContext");

    public Task<Item?> UpdateAsync(int id, Item item)
        => throw new NotImplementedException("Erstat med EF Core DbContext");

    public Task<bool> DeleteAsync(int id)
        => throw new NotImplementedException("Erstat med EF Core DbContext");
}
