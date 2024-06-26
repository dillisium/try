using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data.Models;
using TodoListApp.Data.Repositories;
using TodoListApp.WebApi.DTOs;

namespace TodoListApp.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _repository;
		private readonly IMapper _mapper;

		public UserController(IUserRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var users = await _repository.GetAllAsync();
			var userDtos = _mapper.Map<IEnumerable<UserDto>>(users);
			return Ok(userDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var user = await _repository.GetByIdAsync(id);
			if (user == null)
			{
				return NotFound();
			}
			var userDto = _mapper.Map<UserDto>(user);
			return Ok(userDto);
		}

		[HttpPost]
		public async Task<IActionResult> Create(UserDto userDto)
		{
			var user = _mapper.Map<User>(userDto);
			await _repository.AddAsync(user);
			return CreatedAtAction(nameof(GetById), new { id = user.Id }, userDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UserDto userDto)
		{
			if (id != userDto.Id)
			{
				return BadRequest();
			}
			var user = _mapper.Map<User>(userDto);
			await _repository.UpdateAsync(user);
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
