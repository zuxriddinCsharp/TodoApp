using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(30,ErrorMessage ="Maximal length 30")]
        [MinLength(3,ErrorMessage ="Minimal length 3")]
        public string Name { get; set; }
    }
}
