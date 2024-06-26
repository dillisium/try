using System.Text;
using Newtonsoft.Json;
using TodoListApp.WebApp.Models;

namespace TodoListApp.WebApp.Services
{
    public class ToDoListService : IToDoListService
	{
		private readonly HttpClient _httpClient;

		public ToDoListService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<IEnumerable<ToDoListViewModel>> GetAllAsync()
		{
			var response = await _httpClient.GetAsync($"api/todolist");
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<IEnumerable<ToDoListViewModel>>(content);
		}

		public async Task<ToDoListViewModel> GetByIdAsync(int id)
		{
			var response = await _httpClient.GetAsync($"api/todolist/{id}");
			response.EnsureSuccessStatusCode();
			var content = await response.Content.ReadAsStringAsync();
			return JsonConvert.DeserializeObject<ToDoListViewModel>(content);
		}

		public async Task CreateAsync(ToDoListViewModel toDoListViewModel)
		{
			var content = new StringContent(JsonConvert.SerializeObject(toDoListViewModel), Encoding.UTF8, "application/json");
			var response = await _httpClient.PostAsync("api/todolist", content);
			response.EnsureSuccessStatusCode();
		}

		public async Task UpdateAsync(ToDoListViewModel toDoListViewModel)
		{
			var content = new StringContent(JsonConvert.SerializeObject(toDoListViewModel), Encoding.UTF8, "application/json");
			var response = await _httpClient.PutAsync($"api/todolist/{toDoListViewModel.Id}", content);
			response.EnsureSuccessStatusCode();
		}

		public async Task DeleteAsync(int id)
		{
			var response = await _httpClient.DeleteAsync($"api/todolist/{id}");
			response.EnsureSuccessStatusCode();
		}
	}
}
