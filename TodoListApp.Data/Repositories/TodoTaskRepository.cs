using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Repositories
{
	public class TodoTaskRepository : ITodoTaskRepository
	{
		private readonly TodoListDbContext _context;

		public TodoTaskRepository(TodoListDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<TodoTask>> GetAllAsync()
		{
			return await _context.Tasks.ToListAsync();
		}

		public async Task<TodoTask> GetByIdAsync(int id)
		{
			return await _context.Tasks.FindAsync(id);
		}

		public async Task AddAsync(TodoTask task)
		{
			await _context.Tasks.AddAsync(task);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(TodoTask task)
		{
			_context.Tasks.Update(task);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var task = await _context.Tasks.FindAsync(id);
			if (task != null)
			{
				_context.Tasks.Remove(task);
				await _context.SaveChangesAsync();
			}
		}
	}
}
