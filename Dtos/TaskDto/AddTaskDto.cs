using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace todolist_dotnet.Dtos
{
    public class AddTaskDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsComplete { get; set; }
    }
}