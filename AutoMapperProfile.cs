using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist_dotnet.Dtos.TaskDto;
using todolist_dotnet.Models;

namespace todolist_dotnet
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TaskModel, GetTaskDto>();
        }
    }
}