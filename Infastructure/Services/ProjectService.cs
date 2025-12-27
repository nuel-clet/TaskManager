using Application.DTOs.Projects;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Infastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Services
{
    public class ProjectService : IProjectService
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ProjectService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ProjectResponse> CreateAsync(int userId, CreateProjectRequest request)
        {

            var userExists = await _context.Users.AnyAsync(u => u.Id == userId);
            if (!userExists)
            {
                throw new InvalidOperationException("Creator user not found");
            }

            var project = new Project
            {
                Name = request.Name,
                Description = request.Description,
                CreatedBy = userId
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return _mapper.Map<ProjectResponse>(project);
        }

        public async Task<IEnumerable<ProjectResponse>> GetMyProjectsAsync(int userId)
        {
            var projects = await _context.Projects
           .Where(p => p.CreatedBy == userId)
           .ToListAsync();

            return _mapper.Map<IEnumerable<ProjectResponse>>(projects);
        }
    }
}
