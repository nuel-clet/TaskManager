using Domain.Common;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Task_Status Status { get; set; } = Task_Status.Todo;

        public long ProjectId { get; set; }
        public Project Project { get; set; }

        public long AssignedUserId { get; set; }
        public User AssignedUser { get; set; }

        public DateTime DueDate { get; set; }
    }
}
