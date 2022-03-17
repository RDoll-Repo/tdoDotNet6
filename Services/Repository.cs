using todoDotNet6.models;
namespace todoDotNet6.Services;

// Template to have the dependencies from service container 
// ready for the Repository. 
public interface IRepository
{
    public static Dictionary<Guid, ToDo>? listToDo { get; set; }
    public IEnumerable<ToDo> GetAll();
    public ToDo GetOne(Guid id);
    public ToDo Create(ToDo newToDo);
    public ToDo Update(ToDo update, Guid id);
    public void Delete(Guid ID);
}

public class Repository : IRepository 
{
    public static Dictionary<Guid, ToDo> listToDo = new Dictionary<Guid, ToDo>() {};

    public IEnumerable<ToDo> GetAll() 
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