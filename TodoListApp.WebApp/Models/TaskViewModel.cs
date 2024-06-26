using System.ComponentModel.DataAnnotations;

namespace TodoListApp.WebApp.Models
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string Status { get; set; }

        public int ToDoListId { get; set; }

        public bool IsOverdue => DueDate < DateTime.Now && Status != "Completed";
    }
}
