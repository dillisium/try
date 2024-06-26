using Microsoft.AspNetCore.Mvc;
using TodoListApp.WebApp.Models;
using TodoListApp.WebApp.Services;

namespace TodoListApp.WebApp.Controllers
{
    // Controllers/ToDoListMvcController.cs
    public class ToDoListMvcController : Controller
    {
        private readonly ToDoListService _service;

        public ToDoListMvcController(ToDoListService service)
        {
            _service = service;
        }

        // GET: ToDoListMvc
        public async Task<IActionResult> Index()
        {
            var toDoLists = await _service.GetAllAsync();
            return View(toDoLists);
        }

        // GET: ToDoListMvc/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var toDoList = await _service.GetByIdAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        // GET: ToDoListMvc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDoListMvc/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoListViewModel toDoListViewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(toDoListViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(toDoListViewModel);
        }

        // GET: ToDoListMvc/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var toDoList = await _service.GetByIdAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoListMvc/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ToDoListViewModel toDoListViewModel)
        {
            if (id != toDoListViewModel.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(toDoListViewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(toDoListViewModel);
        }

        // GET: ToDoListMvc/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var toDoList = await _service.GetByIdAsync(id);
            if (toDoList == null)
            {
                return NotFound();
            }
            return View(toDoList);
        }

        // POST: ToDoListMvc/Delete/5
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }

}
