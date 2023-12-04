using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist_dotnet.Data;
using todolist_dotnet.Dtos.TaskDto;
using todolist_dotnet.Models;

namespace todolist_dotnet.Services.TaskService
{
    public class TaskService : ITaskService
    {
        //private readonly IMapper _mapper //TODO
        private readonly DataContext _context; //TODO

        public TaskService(/*IMapper mapper,*/DataContext context)
        {
            _context = context;
            //_mapper = mapper;
        }

        public Task<ServiceResponse<GetTaskDto>> GetCharacterById(int id)
        {
            throw new NotImplementedException();
        }
    }
}