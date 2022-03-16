using todoDotNet6.models.ToDo;
namespace todoDotNet6.Services;

public interface IToDo {
    Guid ID {get;}
    string? TaskDescription {get;set;}
    DateTime CreatedAt {get;}
    DateTime DueDate {get;set;}
    bool Completed {get;set;}
}

// Template to have the dependencies from service container 
// ready for the Repository. 
public interface IRepository
{
    public static Dictionary<Guid, ToDo>? listToDo { get; set; }
    public object GetAll();
    public object GetOne(Guid id);
    public object Create(ToDo newToDo);
    public object Update(ToDo update, Guid id);
    public object Delete(Guid ID);
}

public class Repository : IRepository {

    // A mock data store. Will empty once we implement postgress.
    public static Dictionary<Guid, ToDo> listToDo = new Dictionary<Guid, ToDo>() 
    {
        {Guid.Parse("236cb2ad-d971-4bf1-88c7-3c70b6003fa7"), new ToDo {
        ID = Guid.Parse("236cb2ad-d971-4bf1-88c7-3c70b6003fa7"), 
        TaskDescription = "CRUD", 
        DueDate = DateTime.Parse("03-15-2022"), 
        Completed = true
        }},

        {Guid.Parse("36909e34-1bab-4e0c-8554-a64c3741112b"), new ToDo {
        ID = Guid.Parse("36909e34-1bab-4e0c-8554-a64c3741112b"), 
        TaskDescription = "Repository Pattern",
        DueDate = DateTime.Parse("03-14-2022"), 
        Completed = false}
        }
    };

    // 
    public object GetAll() 
    {
        return listToDo.Values;
    }

    public object GetOne(Guid id) 
    {
        return listToDo[id];
    }

    public object Create(ToDo newToDo) 
    {
        var newID = Guid.NewGuid();
        newToDo.ID = newID;

        listToDo.Add(newID,newToDo);

        return newToDo;
    }

    public object Update(ToDo update, Guid id)
    {
        listToDo[id].TaskDescription = update.TaskDescription;
        listToDo[id].DueDate = update.DueDate;
        listToDo[id].Completed = update.Completed;
        return listToDo[id];
    }

    public object Delete(Guid id)
    {
        listToDo.Remove(id);
        return null;
    }
}


