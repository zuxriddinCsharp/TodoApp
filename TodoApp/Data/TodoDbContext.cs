using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext: DbContext
    {
        public virtual DbSet<Todo> Todos { get; set; }
        public virtual DbSet<TodoTask> TodoTasks {  get; set; }
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) 
        {

        }
        public DbSet<TodoApp.Models.TodoTask> TodoTask { get; set; } = default!;
    }
}
