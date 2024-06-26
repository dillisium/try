using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Context;
using TodoListApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Data.Repositories
{
	public class CommentRepository : ICommentRepository
	{
		private readonly TodoListDbContext _context;

		public CommentRepository(TodoListDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Comment>> GetAllAsync()
		{
			return await _context.Comments.ToListAsync();
		}

		public async Task<Comment> GetByIdAsync(int id)
		{
			return await _context.Comments.FindAsync(id);
		}

		public async Task AddAsync(Comment comment)
		{
			await _context.Comments.AddAsync(comment);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(Comment comment)
		{
			_context.Comments.Update(comment);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(int id)
		{
			var comment = await _context.Comments.FindAsync(id);
			if (comment != null)
			{
				_context.Comments.Remove(comment);
				await _context.SaveChangesAsync();
			}
		}
	}
}
