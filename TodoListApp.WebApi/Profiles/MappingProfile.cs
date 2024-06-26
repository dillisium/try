using TodoListApp.Data.Models;
using TodoListApp.WebApi.DTOs;
using AutoMapper;

namespace TodoListApp.WebApi.Profiles
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<ToDoList, ToDoListDto>().ReverseMap();
			CreateMap<Task, TaskDto>().ReverseMap();
			CreateMap<Tag, TagDto>().ReverseMap();
			CreateMap<Comment, CommentDto>().ReverseMap();
			CreateMap<User, UserDto>().ReverseMap();
		}
	}
}
