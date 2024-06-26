using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoListApp.WebApp.Models;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.Controllers
{
    public class TaskMvcController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskMvcController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        public IActionResult Create(int toDoListId)
        {
            return View(new TaskViewModel { ToDoListId = toDoListId });
        }

        [HttpPost]
        public async Task<IActionResult> Create(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _taskService.CreateAsync(model);
                return RedirectToAction("Details", "ToDoListMvc", new { id = model.ToDoListId });
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TaskViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _taskService.UpdateAsync(model);
                return RedirectToAction("Details", "ToDoListMvc", new { id = model.ToDoListId });
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var task = await _taskService.GetByIdAsync(id);
            await _taskService.DeleteAsync(id);
            return RedirectToAction("Details", "ToDoListMvc", new { id = task.ToDoListId });
        }
    }
}

