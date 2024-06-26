using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data.Context;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Repositories
{
	public class TagRepository : ITagRepository
	{
		private readonly TodoListDbContext _context;

		public TagRepository(TodoListDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Tag>> GetAllAsync()
		{
			return await _context.Tags.ToListAsync();
		}

		public async Task<Tag> GetByIdAsync(int id)
		{
			return await _context.Tags.FindAsync(id);
		}

		public async Task AddAsync(Tag tag)
		{
			await _context.Tags.AddAsync(tag);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Tag tag)
		{
			_context.Tags.Update(tag);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var tag = await _context.Tags.FindAsync(id);
			if (tag != null)
			{
				_context.Tags.Remove(tag);
				await _context.SaveChangesAsync();
			}
		}
	}
}
