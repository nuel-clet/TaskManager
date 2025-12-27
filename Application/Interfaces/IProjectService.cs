using Application.DTOs.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IProjectService
    {

        Task<ProjectResponse> CreateAsync(int userId, CreateProjectRequest request);
        Task<IEnumerable<ProjectResponse>> GetMyProjectsAsync(int userId);
    }
}
