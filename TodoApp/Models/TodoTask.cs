using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace TodoApp.Models
{
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        [MinLength(5)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Due_Data { get; set; }
        public ToDoStatus Status { get; set; }
        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }
    }
}
