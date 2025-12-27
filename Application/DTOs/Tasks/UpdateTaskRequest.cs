using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Tasks
{
    public class UpdateTaskRequest
    {
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public Task_Status Status { get; set; }
        public int? AssignedUserId { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
