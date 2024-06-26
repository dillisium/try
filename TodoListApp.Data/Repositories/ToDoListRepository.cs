using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Models;
using TodoListApp.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Data.Repositories
{
	public class ToDoListRepository : IToDoListRepository
	{
		private readonly TodoListDbContext _context;

		public ToDoListRepository(TodoListDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ToDoList>> GetAllAsync()
		{
			return await _context.ToDoLists.ToListAsync();
		}

		public async Task<ToDoList> GetByIdAsync(int id)
		{
			return await _context.ToDoLists.FindAsync(id);
		}

		public async Task AddAsync(ToDoList toDoList)
		{
			await _context.ToDoLists.AddAsync(toDoList);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(ToDoList toDoList)
		{
			_context.ToDoLists.Update(toDoList);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var toDoList = await _context.ToDoLists.FindAsync(id);
			if (toDoList != null)
			{
				_context.ToDoLists.Remove(toDoList);
				await _context.SaveChangesAsync();
			}
		}
	}
}
