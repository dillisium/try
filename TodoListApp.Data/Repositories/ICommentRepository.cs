using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Repositories
{
	public interface ICommentRepository
	{
		Task<IEnumerable<Comment>> GetAllAsync();
		Task<Comment> GetByIdAsync(int id);
		Task AddAsync(Comment comment);
		Task UpdateAsync(Comment comment);
		Task DeleteAsync(int id);
	}
}
