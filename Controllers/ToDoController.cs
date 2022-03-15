using Microsoft.AspNetCore.Mvc;
using todoDotNet6.models.ToDo;
using todoDotNet6.Services;

namespace todoDotNet6.Controllers;

[ApiController]
[Route("todolist")]

public class ToDoController:ControllerBase {

    [HttpGet("tasks")]
    public ActionResult<IEnumerable<ToDo>> Get()
    {   
        return Ok(Repository.getAll());
    }



    [HttpGet("tasks/{id}")]
    public ActionResult<ToDo> Get(Guid id) 
    {   

        return Ok(Repository.listToDo[id]);
    }



    [HttpPost("tasks")]
    public ActionResult<ToDo> Post([FromBody]ToDo toDo)
    {
        var newID = Guid.NewGuid();
        
        toDo.ID = newID;

        Repository.listToDo.Add(newID,toDo);

        return Created(uri:"tasks/{id}", toDo);
    }



    [HttpPut("tasks/{id}")]
    public ActionResult<ToDo> Put([FromBody]ToDo toDo, Guid ID) 
    {
        Repository.listToDo[ID].TaskDescription = toDo.TaskDescription;
        Repository.listToDo[ID].DueDate = toDo.DueDate;
        Repository.listToDo[ID].Completed = toDo.Completed;

        return Ok(Repository.listToDo[ID]);
    }



    [HttpDelete("tasks/{id}")]
    public ActionResult<ToDo> Delete(Guid ID) 
    {
        Repository.listToDo.Remove(ID);
        return Ok();
    }

}
