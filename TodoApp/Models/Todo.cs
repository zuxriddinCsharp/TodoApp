using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace TodoApp.Models
{
    public class ToDo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }

        public string Description { get; set; }

        [DisplayName("Status")]
        public ToDoStatus todoStatus { get; set; } = ToDoStatus.NotStarted;

        public ICollection<ToDoTask> ToDoTasks { get; set; }

        public ToDo()
        {
            ToDoTasks = [];
        }
    }
}
