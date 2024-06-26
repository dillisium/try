using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoListApp.Data.Models;

namespace TodoListApp.Data.Context
{
	public class TodoListDbContext : DbContext
	{
		//public TodoListDbContext()
		//{

		//}
		public TodoListDbContext(DbContextOptions<TodoListDbContext> options) : base(options) { }

        public DbSet<ToDoList> ToDoLists { get; set; }
		public DbSet<TodoTask> Tasks { get; set; }
		public DbSet<Tag> Tags { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<User> Users { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Configure relationships and constraints

			// ToDoList to Task relationship
			modelBuilder.Entity<ToDoList>()
				.HasMany(t => t.Tasks)
				.WithOne(t => t.ToDoList)
				.HasForeignKey(t => t.ToDoListId);

			// Task to Tag relationship (Many-to-Many)
			modelBuilder.Entity<TodoTask>()
				.HasMany(t => t.Tags)
				.WithMany(t => t.Tasks)
				.UsingEntity(j => j.ToTable("TaskTags"));

			// Task to Comment relationship
			modelBuilder.Entity<TodoTask>()
				.HasMany(t => t.Comments)
				.WithOne(c => c.Task)
				.HasForeignKey(c => c.TaskId);

			// User to Task relationship
			modelBuilder.Entity<User>()
				.HasMany(u => u.Tasks)
				.WithOne(t => t.Assignee)
				.HasForeignKey(t => t.AssigneeId);

			// User to ToDoList relationship
			//modelBuilder.Entity<User>()
			//	.HasMany(u => u.ToDoLists)
			//	.WithOne()
			//	.HasForeignKey(t => t.AssigneeId); // Assuming a ToDoList can be assigned to a user as well

			// Additional configurations
			modelBuilder.Entity<User>()
				.HasIndex(u => u.Email)
				.IsUnique();

			modelBuilder.Entity<Tag>()
				.HasIndex(t => t.Name)
				.IsUnique();

			// Setting default values and constraints
			modelBuilder.Entity<TodoTask>()
				.Property(t => t.CreatedDate)
				.HasDefaultValueSql("GETDATE()");

			modelBuilder.Entity<TodoTask>()
				.Property(t => t.Status)
				.HasDefaultValue("Not Started");

			modelBuilder.Entity<Comment>()
				.Property(c => c.CreatedDate)
				.HasDefaultValueSql("GETDATE()");
		}
	}
}
