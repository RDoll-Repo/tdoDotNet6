using Microsoft.AspNetCore.Mvc;
using todoDotNet6.models;
using todoDotNet6.Services;

namespace todoDotNet6.Controllers;

[ApiController]
[Route("todolist")]

public class ToDoController:ControllerBase 
{
    private readonly Repository repo = new Repository();

    [HttpGet("tasks")]
    public ActionResult<IEnumerable<ToDo>> Get()
    {   
        return Ok(repo.GetAll());
    }



    [HttpGet("tasks/{id}")]
    public ActionResult<ToDo> Get(Guid id) 
    {          
        ToDo single = repo.GetOne(id);
        
        if (single == null)
        {
            return NotFound();
        }
        return Ok(repo.GetOne(id));
    }



    [HttpPost("tasks")]
    public ActionResult<ToDo> Post([FromBody]ToDo toDo)
    {
        return Created(uri:"tasks/{id}", repo.Create(toDo));
    }



    [HttpPut("tasks/{id}")]
    public ActionResult<ToDo> Put([FromBody]ToDo toDo, Guid ID) 
    {
        return Ok(repo.Update(toDo, ID));
    }



    [HttpDelete("tasks/{id}")]
    public ActionResult<ToDo> Delete(Guid ID) 
    {
        repo.Delete(ID);
        return Ok();
    }
}
