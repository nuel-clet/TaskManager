using Domain.Enums;

namespace Application.DTOs.Tasks
{
    public class TaskResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Task_Status Status { get; set; }
    }
}
