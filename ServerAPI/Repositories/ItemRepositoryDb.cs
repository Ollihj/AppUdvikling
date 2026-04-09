using Core.Models;
using MongoDB.Driver;


namespace ServerAPI.Repositories;

public class ItemRepositoryDb : IItemRepository
{
    private readonly IMongoCollection<Item> _items;

    public ItemRepositoryDb()
    {
        var client = new MongoClient("mongodb+srv://test:test123@cluster0.obirjav.mongodb.net/");
        var database = client.GetDatabase("WebAppDatabase");
        _items = database.GetCollection<Item>("Clothes");
    }

    public List<Item> GetAll()
    {
        return _items.Find(item => true).ToList();
    }

    public Item Add(Item item)
    {
        var maxId = _items.Find(_ => true).SortByDescending(x => x.Id).FirstOrDefault()?.Id ?? 0;
        item.Id = maxId + 1;
        _items.InsertOne(item);
        return item;
    }

    public Item Toggle(int id)
    {
        var item = _items.Find(item => item.Id == id).First();

        var updateDef = Builders<Item>.Update
            .Set(x => x.ErLedig, !item.ErLedig);
        _items.UpdateOne(x => x.Id == item.Id, updateDef);
        
        item.ErLedig = !item.ErLedig;
        return item;
    }

    public void DeleteById(int id)
    {
        _items.DeleteOne(_items => _items.Id == id);
    }

}
