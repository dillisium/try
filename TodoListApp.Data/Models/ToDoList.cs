using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Data.Models
{
	public class ToDoList
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public ICollection<TodoTask> Tasks { get; set; }
	}
}
