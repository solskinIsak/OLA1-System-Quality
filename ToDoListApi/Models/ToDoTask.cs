using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OLA1_SofQuality.ToDoListApi.Models
{
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}