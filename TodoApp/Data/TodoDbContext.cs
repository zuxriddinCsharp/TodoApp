using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class TodoDbContext: DbContext
    {
        public virtual DbSet<ToDo> ToDoes { get; set; }
        public virtual DbSet<ToDoTask> ToDoTasks {  get; set; }
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) 
        {
        }
    }
}
