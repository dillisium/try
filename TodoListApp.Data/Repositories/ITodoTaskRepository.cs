using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Repositories
{
	public interface ITodoTaskRepository
	{
		Task<IEnumerable<TodoTask>> GetAllAsync();
		Task<TodoTask> GetByIdAsync(int id);
		Task AddAsync(TodoTask task);
		Task UpdateAsync(TodoTask task);
		Task DeleteAsync(int id);
	}
}