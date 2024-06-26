using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data.Models;
using TodoListApp.Data.Repositories;
using TodoListApp.WebApi.DTOs;

namespace TodoListApp.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CommentController : ControllerBase
	{
		private readonly ICommentRepository _repository;
		private readonly IMapper _mapper;

		public CommentController(ICommentRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var comments = await _repository.GetAllAsync();
			var commentDtos = _mapper.Map<IEnumerable<CommentDto>>(comments);
			return Ok(commentDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var comment = await _repository.GetByIdAsync(id);
			if (comment == null)
			{
				return NotFound();
			}
			var commentDto = _mapper.Map<CommentDto>(comment);
			return Ok(commentDto);
		}

		[HttpPost]
		public async Task<IActionResult> Create(CommentDto commentDto)
		{
			var comment = _mapper.Map<Comment>(commentDto);
			await _repository.AddAsync(comment);
			return CreatedAtAction(nameof(GetById), new { id = comment.Id }, commentDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, CommentDto commentDto)
		{
			if (id != commentDto.Id)
			{
				return BadRequest();
			}
			var comment = _mapper.Map<Comment>(commentDto);
			await _repository.UpdateAsync(comment);
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
