using Microsoft.AspNetCore.Mvc;
using MinApp.Core.Models;
using MinApp.Server.Repositories;

namespace MinApp.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private IRepo repo;

    public ItemsController(IRepo repo)
    {
        this.repo = repo;
    }

    [HttpGet]
    public Item[] GetAll() => repo.GetAll();

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var item = repo.GetById(id);
        if (item is null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public IActionResult Add([FromBody] Item item)
    {
        repo.Add(item);
        return Ok(item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Item item)
    {
        item.Id = id;
        repo.Update(item);
        return Ok(item);
    }

    [HttpDelete("delete")]
    public IActionResult DeleteById([FromQuery] int id)
    {
        repo.DeleteById(id);
        return Ok();
    }
}
