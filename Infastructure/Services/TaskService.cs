using Application.DTOs.Tasks;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Infastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Services
{
    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public TaskService(ApplicationDbContext context, IMapper mapper)
        {

            _context = context;
            _mapper = mapper;
        }

        public async Task<TaskResponse> CreateAsync(CreateTaskRequest request)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                ProjectId = request.ProjectId,
                AssignedUserId = request.AssignedUserId ?? 0,
                DueDate = request.DueDate ?? DateTime.UtcNow,
            };

            _context.TaskItems.Add(task);
            await _context.SaveChangesAsync();

            return _mapper.Map<TaskResponse>(task);
        }

        public async Task<IEnumerable<TaskResponse>> GetAsync(int projectId, int page, int pageSize, string? status)
        {
            var query = _context.TaskItems.Where(t => t.ProjectId == projectId);

            if (!string.IsNullOrEmpty(status) &&
                Enum.TryParse<Task_Status>(status, true, out var taskStatus))
            {
                query = query.Where(t => t.Status == taskStatus);
            }

            var tasks = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return _mapper.Map<IEnumerable<TaskResponse>>(tasks);
        }

        public async Task<TaskResponse> UpdateAsync(long taskId, UpdateTaskRequest request)
        {
            var task = await _context.TaskItems.FindAsync(taskId)
           ?? throw new Exception("Task not found");

            task.Title = request.Title ?? task.Title;
            task.Description = request.Description ?? task.Description;
            task.Status = request.Status;
            task.AssignedUserId = request.AssignedUserId ?? task.AssignedUserId;
            task.DueDate = request.DueDate ?? DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return _mapper.Map<TaskResponse>(task);
        }
    }
}
