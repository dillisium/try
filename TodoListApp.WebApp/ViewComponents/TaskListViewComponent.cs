using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.WebApp.Models;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.ViewComponents
{
    public class TaskListViewComponent : ViewComponent
    {
        private readonly ITaskService _taskService;

        public TaskListViewComponent(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int toDoListId)
        {
            var tasks = await _taskService.GetTasksByToDoListIdAsync(toDoListId);
            return View(tasks);
        }
    }
}
