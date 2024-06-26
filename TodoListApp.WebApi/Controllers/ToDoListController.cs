using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data.Models;
using TodoListApp.Data.Repositories;
using TodoListApp.WebApi.DTOs;
using AutoMapper;

namespace TodoListApp.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ToDoListController : ControllerBase
	{
		private readonly IToDoListRepository _repository;
		private readonly IMapper _mapper;

		public ToDoListController(IToDoListRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var toDoLists = await _repository.GetAllAsync();
			var toDoListDtos = _mapper.Map<IEnumerable<ToDoListDto>>(toDoLists);
			return Ok(toDoListDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var toDoList = await _repository.GetByIdAsync(id);
			if (toDoList == null)
			{
				return NotFound();
			}
			var toDoListDto = _mapper.Map<ToDoListDto>(toDoList);
			return Ok(toDoListDto);
		}

		[HttpPost]
		public async Task<IActionResult> Create(ToDoListDto toDoListDto)
		{
			var toDoList = _mapper.Map<ToDoList>(toDoListDto);
			await _repository.AddAsync(toDoList);
			return CreatedAtAction(nameof(GetById), new { id = toDoList.Id }, toDoListDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, ToDoListDto toDoListDto)
		{
			if (id != toDoListDto.Id)
			{
				return BadRequest();
			}
			var toDoList = _mapper.Map<ToDoList>(toDoListDto);
			await _repository.UpdateAsync(toDoList);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _repository.DeleteAsync(id);
			return NoContent();
		}
	}
}
