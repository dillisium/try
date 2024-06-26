using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListApp.Data.Models;
using TodoListApp.Data.Repositories;
using TodoListApp.WebApi.DTOs;

namespace TodoListApp.WebApi.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class TagController : ControllerBase
	{
		private readonly ITagRepository _repository;
		private readonly IMapper _mapper;

		public TagController(ITagRepository repository, IMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var tags = await _repository.GetAllAsync();
			var tagDtos = _mapper.Map<IEnumerable<TagDto>>(tags);
			return Ok(tagDtos);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var tag = await _repository.GetByIdAsync(id);
			if (tag == null)
			{
				return NotFound();
			}
			var tagDto = _mapper.Map<TagDto>(tag);
			return Ok(tagDto);
		}

		[HttpPost]
		public async Task<IActionResult> Create(TagDto tagDto)
		{
			var tag = _mapper.Map<Tag>(tagDto);
			await _repository.AddAsync(tag);
			return CreatedAtAction(nameof(GetById), new { id = tag.Id }, tagDto);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, TagDto tagDto)
		{
			if (id != tagDto.Id)
			{
				return BadRequest();
			}
			var tag = _mapper.Map<Tag>(tagDto);
			await _repository.UpdateAsync(tag);
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
