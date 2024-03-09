using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace TodoApp.Models
{
    public class TodoTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Due_Data { get; set; }
        public TodoStatus Status { get; set; }
        
        public Todo todo_ { get; set; }
    }
}
