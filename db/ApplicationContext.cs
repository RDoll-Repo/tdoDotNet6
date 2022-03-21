using Microsoft.EntityFrameworkCore;
using todoDotNet6.models;

namespace todoDotNet6.db
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) {}
        
        public DbSet<ToDo> toDos { get; set; }
    }
}