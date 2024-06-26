using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TodoListApp.Data.Models
{
	public class TodoTask
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime DueDate { get; set; }
		public string Status { get; set; }
		public int AssigneeId { get; set; }
		public User Assignee { get; set; }
		public ICollection<Tag> Tags { get; set; }
		public ICollection<Comment> Comments { get; set; }
		public int ToDoListId { get; set; }
		public ToDoList ToDoList { get; set; }

	}
}
