using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Projects
{
    public class CreateProjectRequest
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}
