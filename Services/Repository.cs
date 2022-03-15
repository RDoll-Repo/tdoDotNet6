using todoDotNet6.models.ToDo;

namespace todoDotNet6.Services;

public interface IEntity<TIndex>
{
    TIndex ID {get;set;}
}

public interface IToDo {
    Guid ID {get;}
    string? TaskDescription {get;set;}
    DateTime CreatedAt {get;}
    DateTime DueDate {get;set;}
    bool Completed {get;set;}
}

public interface IDictionary <ToDo, Guid> 
{

}

public class Repository {
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

    public static object getAll() {
        return listToDo;
    }
}


