global using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todolist_dotnet.Data;
using todolist_dotnet.Dtos.TaskDto;
using todolist_dotnet.Models;

namespace todolist_dotnet.Services.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context; 

        public TaskService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            serviceResponse.Data = _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToList();

            return serviceResponse;
        }

        public Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            throw new NotImplementedException();
        }
    }
}