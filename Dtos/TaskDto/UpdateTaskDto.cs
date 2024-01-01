using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todolist_dotnet.Dtos.TaskDto
{
    public class UpdateTaskDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}