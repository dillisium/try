namespace TodoListApp.WebApi.DTOs
{
	public class TaskDto
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DueDate { get; set; }
		public string Status { get; set; }
		public int AssigneeId { get; set; }
		public int ToDoListId { get; set; }
	}
}
