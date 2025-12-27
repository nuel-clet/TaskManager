using Application.DTOs.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITaskService
    {
        Task<TaskResponse> CreateAsync(CreateTaskRequest request);
        Task<IEnumerable<TaskResponse>> GetAsync(
            int projectId,
            int page,
            int pageSize,
            string? status);
        Task<TaskResponse> UpdateAsync(long taskId, UpdateTaskRequest request);
    }
}
