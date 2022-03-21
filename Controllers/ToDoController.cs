using Microsoft.AspNetCore.Mvc;
using todoDotNet6.db;
using todoDotNet6.models;
using todoDotNet6.Services;

namespace todoDotNet6.Controllers;

[ApiController]
[Route("todolist")]

public class ToDoController:ControllerBase 
{
    private readonly IRepository _repo;

    public ToDoController(ApplicationContext context, IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("tasks")]
    public async Task<ActionResult<IEnumerable<ToDo>>> Get()
    {   
        var list = await _repo.GetAll();
        return Ok(list);
    }



    [HttpGet("tasks/{id}")]
    public async Task<ActionResult<ToDo>> Get(Guid id) 
    {          
        ToDo single = await _repo.GetOne(id);
        
        if (single == null)
        {
            return NotFound();
        }
        return Ok(single);
    }



    [HttpPost("tasks")]
    public async Task<ActionResult<ToDo>> Post([FromBody]ToDo toDo)
    {
        return Created(uri:"tasks/{id}", await _repo.Create(toDo));
    }



    [HttpPut("tasks/{id}")]
    public async Task<ActionResult<ToDo>> Put([FromBody]ToDo toDo, Guid ID) 
    {
        return Ok(await _repo.Update(toDo, ID));
    }



    [HttpDelete("tasks/{id}")]
    public ActionResult<ToDo> Delete(Guid ID) 
    {
        _repo.Delete(ID);
        return Ok();
    }
}
