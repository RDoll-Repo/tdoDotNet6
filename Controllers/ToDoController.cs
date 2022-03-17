using Microsoft.AspNetCore.Mvc;
using todoDotNet6.models;
using todoDotNet6.Services;

namespace todoDotNet6.Controllers;

[ApiController]
[Route("todolist")]

public class ToDoController:ControllerBase 
{
    private readonly IRepository _repo;

    public ToDoController(IRepository repo)
    {
        _repo = repo;
    }

    [HttpGet("tasks")]
    public ActionResult<IEnumerable<ToDo>> Get()
    {   
        return Ok(_repo.GetAll());
    }



    [HttpGet("tasks/{id}")]
    public ActionResult<ToDo> Get(Guid id) 
    {          
        ToDo single = _repo.GetOne(id);
        
        if (single == null)
        {
            return NotFound();
        }
        return Ok(_repo.GetOne(id));
    }



    [HttpPost("tasks")]
    public ActionResult<ToDo> Post([FromBody]ToDo toDo)
    {
        return Created(uri:"tasks/{id}", _repo.Create(toDo));
    }



    [HttpPut("tasks/{id}")]
    public ActionResult<ToDo> Put([FromBody]ToDo toDo, Guid ID) 
    {
        return Ok(_repo.Update(toDo, ID));
    }



    [HttpDelete("tasks/{id}")]
    public ActionResult<ToDo> Delete(Guid ID) 
    {
        _repo.Delete(ID);
        return Ok();
    }
}
