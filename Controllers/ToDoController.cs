using Microsoft.AspNetCore.Mvc;
using todoDotNet6.models.ToDo;
using todoDotNet6.Services;

namespace todoDotNet6.Controllers;

[ApiController]
[Route("todolist")]

public class ToDoController:ControllerBase {

    Repository repo = new Repository();

    [HttpGet("tasks")]
    public ActionResult<IEnumerable<ToDo>> Get()
    {   
        return Ok(repo.GetAll());
    }



    [HttpGet("tasks/{id}")]
    public ActionResult<ToDo> Get(Guid id) 
    {   
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
        return Ok(repo.Delete(ID));
    }

}
