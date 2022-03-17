using todoDotNet6.models;
namespace todoDotNet6.Services;

public interface IToDo {
    Guid ID { get; }
    string? TaskDescription { get; set; }
    DateTime CreatedAt { get; }
    DateTime DueDate { get; set; }
    bool Completed { get; set; }
}

// Template to have the dependencies from service container 
// ready for the Repository. 
public interface IRepository
{
    public static Dictionary<Guid, ToDo>? listToDo { get; set; }
    public ToDo[] GetAll();
    public ToDo GetOne(Guid id);
    public ToDo Create(ToDo newToDo);
    public ToDo Update(ToDo update, Guid id);
    public void Delete(Guid ID);
}

public class Repository : IRepository 
{
    // A mock data store. Will empty once we implement postgress.
    public static Dictionary<Guid, ToDo> listToDo = new Dictionary<Guid, ToDo>() 
    {
        {
            Guid.Parse("236cb2ad-d971-4bf1-88c7-3c70b6003fa7"), 
            new ToDo 
            {
                ID = Guid.Parse("236cb2ad-d971-4bf1-88c7-3c70b6003fa7"), 
                TaskDescription = "CRUD", 
                DueDate = DateTime.Parse("03-15-2022"), 
                Completed = true
            }
        },

        {
            Guid.Parse("36909e34-1bab-4e0c-8554-a64c3741112b"), 
            new ToDo 
            {
                ID = Guid.Parse("36909e34-1bab-4e0c-8554-a64c3741112b"), 
                TaskDescription = "Repository Pattern",
                DueDate = DateTime.Parse("03-14-2022"), 
                Completed = false
            }
        }
    };

    public ToDo[] GetAll() 
    {
        return listToDo.Values.ToArray();
    }

    public ToDo GetOne(Guid id) 
    {
        if (listToDo.ContainsKey(id))
        {
            return listToDo[id];
        }
        else
        {
            return null;
        }
    }

    public ToDo Create(ToDo newToDo) 
    {
        Guid newID  = Guid.NewGuid();
        while (listToDo.ContainsKey(newID))
        {
            newID = Guid.NewGuid();
        }
        newToDo.ID = newID;
        listToDo.Add(newID,newToDo);

        return newToDo;
    }

    public ToDo Update(ToDo update, Guid id)
    {
        listToDo[id] = update;
        listToDo[id].ID = id;
        return listToDo[id];
    }

    public void Delete(Guid id)
    {
        listToDo.Remove(id);
    }
}