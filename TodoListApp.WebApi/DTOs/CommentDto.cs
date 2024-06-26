namespace TodoListApp.WebApi.DTOs
{
	public class CommentDto
	{
		public int Id { get; set; }
		public string Text { get; set; }
		public DateTime CreatedDate { get; set; }
		public int TaskId { get; set; }
	}
}
