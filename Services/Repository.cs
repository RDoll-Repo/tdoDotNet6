using todoDotNet6.db;
using todoDotNet6.models;
using Microsoft.EntityFrameworkCore;
namespace todoDotNet6.Services;



// Template to have the dependencies from service container 
// ready for the Repository. 
public interface IRepository
{
    public static Dictionary<Guid, ToDo>? listToDo { get; set; }
    public Task<IEnumerable<ToDo>> GetAll();
    public Task<ToDo> GetOne(Guid id);
    public Task<ToDo> Create(ToDo newToDo);
    public Task<ToDo> Update(ToDo update, Guid id);
    public Task<ToDo?> Delete(Guid ID);
}

public class Repository : IRepository 
{
    private readonly ApplicationContext _context;
    public DbSet<ToDo> _dbSet => _context.Set<ToDo>();

    public Repository( ApplicationContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ToDo>> GetAll() 
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<ToDo> GetOne(Guid id) 
    {
        return await _dbSet.FirstOrDefaultAsync(t => t.ID == id);
    }

    public async Task<ToDo> Create(ToDo newToDo) 
    {
        newToDo.ID = Guid.NewGuid();
        _dbSet.Add(newToDo);
        await _context.SaveChangesAsync();
        return newToDo;
    }
 
    public async Task<ToDo> Update(ToDo update, Guid id)
    {
        update.ID = id;
        _dbSet.Update(update);
        await _context.SaveChangesAsync();

        return update;
    }

    public async Task<ToDo?> Delete(Guid id)
    {
        _dbSet.Remove(new ToDo{ID = id});
        await _context.SaveChangesAsync();
        return null;
    }
}