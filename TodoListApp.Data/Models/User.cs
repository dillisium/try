using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Data.Models
{
	public class User
	{	
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public ICollection<TodoTask> Tasks { get; set; }
		public ICollection<ToDoList> ToDoLists { get; set; }

	}
}
