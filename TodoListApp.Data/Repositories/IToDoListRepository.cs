using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Repositories
{
	public interface IToDoListRepository
	{
		Task<IEnumerable<ToDoList>> GetAllAsync();
		Task<ToDoList> GetByIdAsync(int id);
		Task AddAsync(ToDoList toDoList);
		Task UpdateAsync(ToDoList toDoList);
		Task DeleteAsync(int id);

	}
}
