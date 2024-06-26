using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskViewModel>> GetTasksByToDoListIdAsync(int toDoListId);
        Task<TaskViewModel> GetByIdAsync(int id);
        Task CreateAsync(TaskViewModel model);
        Task UpdateAsync(TaskViewModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<TaskViewModel>> GetOverdueTasksAsync(int toDoListId);
    }
}
