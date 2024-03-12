using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Data
{
    public class ExpenseManagerDbContext:DbContext
    {
        public virtual DbSet<Category> Categories { get; set; }
        public ExpenseManagerDbContext(DbContextOptions<ExpenseManagerDbContext>optionsBuilder)
            : base(optionsBuilder)
        {

        }
    }
}
