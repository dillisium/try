using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Services
{
    public interface IToDoListService
    {
        Task<IEnumerable<ToDoListViewModel>> GetAllAsync();
        Task<ToDoListViewModel> GetByIdAsync(int id);
        Task CreateAsync(ToDoListViewModel toDoListViewModel);
        Task UpdateAsync(ToDoListViewModel toDoListViewModel);
        Task DeleteAsync(int id);
    }
}
