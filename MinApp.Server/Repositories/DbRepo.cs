using MinApp.Core.Models;

namespace MinApp.Server.Repositories;

// Stub til fremtidig databaseimplementering
public class DbRepo : IRepo
{
    public Item[] GetAll() => throw new NotImplementedException();
    public Item? GetById(int id) => throw new NotImplementedException();
    public void Add(Item item) => throw new NotImplementedException();
    public void Update(Item item) => throw new NotImplementedException();
    public void DeleteById(int id) => throw new NotImplementedException();
}
