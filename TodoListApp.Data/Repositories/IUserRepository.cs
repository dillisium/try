﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Context;
using TodoListApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Data.Repositories
{
	public interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllAsync();
		Task<User> GetByIdAsync(int id);
		Task AddAsync(User user);
		Task UpdateAsync(User user);
		Task DeleteAsync(int id);
	}
}
