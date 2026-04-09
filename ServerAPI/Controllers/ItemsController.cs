using Microsoft.AspNetCore.Mvc;
using Core.Models;
using ServerAPI.Repositories;

namespace ServerAPI.Controllers;

[ApiController]
[Route("Home")]
public class ItemsController : ControllerBase
{
    private readonly IItemRepository ItemsRepo;

    public ItemsController(IItemRepository repo)
    {
        ItemsRepo = repo;
    }

    [HttpGet]
    public List<Item> GetAll()
    {
        return ItemsRepo.GetAll();
    }

    [HttpPost]
    public void Add(Item item)
    {
        ItemsRepo.Add(item);
    }

    [HttpDelete("{id}")]
    public void Delete(int id)
    {
        ItemsRepo.DeleteById(id);
    }

    [HttpPut("{id}")]
    public Item Toggle(int id)
    {
        return ItemsRepo.Toggle(id);
    }
}