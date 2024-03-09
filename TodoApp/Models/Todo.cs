using System.ComponentModel;
using System.Runtime.InteropServices;

namespace TodoApp.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DisplayName("Status")]
        public TodoStatus todoStatus { get; set; }
    }
}
