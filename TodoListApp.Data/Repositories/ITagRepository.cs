using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Repositories
{
	public interface ITagRepository
	{
		Task<IEnumerable<Tag>> GetAllAsync();
		Task<Tag> GetByIdAsync(int id);
		Task AddAsync(Tag tag);
		Task UpdateAsync(Tag tag);
		Task DeleteAsync(int id);
	}
}
