using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoListApp.Data.Models
{
	public class Tag
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<TodoTask> Tasks { get; set; }

	}
}
