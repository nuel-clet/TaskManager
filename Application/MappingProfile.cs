using Application.DTOs.Projects;
using Application.DTOs.Tasks;
using Domain.Entities;
using AutoMapper;

namespace Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectResponse>();
            CreateMap<TaskItem, TaskResponse>();
        }
    }
}
