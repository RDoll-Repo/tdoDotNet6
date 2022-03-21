using todoDotNet6.db;
using todoDotNet6.models;
using Microsoft.EntityFrameworkCore;
namespace todoDotNet6.Services;



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
    private readonly ApplicationContext _context;
    public DbSet<ToDo> _dbSet => _context.Set<ToDo>();

    public Repository( ApplicationContext context)
    {
        _context = context;
    }

    public ToDo[] GetAll() 
    {
        return _dbSet.ToArray();
    }

    public ToDo GetOne(Guid id) 
    {
        return _dbSet.Single(td => td.ID == id);
    }

    public ToDo Create(ToDo newToDo) 
    {
        newToDo.ID = Guid.NewGuid();
        newToDo.DueDate = DateTime.SpecifyKind(newToDo.DueDate, DateTimeKind.Utc);
        var todo = _dbSet.Add(newToDo);
        _context.SaveChanges();
        return newToDo;
    }
 
    public ToDo Update(ToDo update, Guid id)
    {
        update.ID = id;
        update.DueDate = DateTime.SpecifyKind(update.DueDate, DateTimeKind.Utc);
        _dbSet.Update(update);
        _context.SaveChanges();

        return update;
    }

    public void Delete(Guid id)
    {
        _dbSet.Remove(new ToDo{ID = id});
        _context.SaveChanges();
    }
}