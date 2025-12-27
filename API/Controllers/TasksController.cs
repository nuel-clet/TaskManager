using Application.DTOs.Tasks;
using Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _service;

        public TasksController(ITaskService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskRequest request)
           => Ok(await _service.CreateAsync(request));


        [HttpGet]
        public async Task<IActionResult> Get(int projectId, int page = 1, int pageSize = 10, string? status = null)
         => Ok(await _service.GetAsync(projectId, page, pageSize, status));


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, UpdateTaskRequest request)
            => Ok(await _service.UpdateAsync(id, request));
    }
}
