using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Services
{
    public class TaskService : ITaskService
    {
        private readonly HttpClient _httpClient;

        public TaskService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<TaskViewModel>> GetTasksByToDoListIdAsync(int toDoListId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskViewModel>>($"api/todolist/{toDoListId}/tasks");
        }

        public async Task<TaskViewModel> GetByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<TaskViewModel>($"api/task/{id}");
        }

        public async Task CreateAsync(TaskViewModel model)
        {
            await _httpClient.PostAsJsonAsync("api/task", model);
        }

        public async Task UpdateAsync(TaskViewModel model)
        {
            await _httpClient.PutAsJsonAsync($"api/task/{model.Id}", model);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/task/{id}");
        }

        public async Task<IEnumerable<TaskViewModel>> GetOverdueTasksAsync(int toDoListId)
        {
            return await _httpClient.GetFromJsonAsync<IEnumerable<TaskViewModel>>($"api/todolist/{toDoListId}/tasks/overdue");
        }
    }
}
