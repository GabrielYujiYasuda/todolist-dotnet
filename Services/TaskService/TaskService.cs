global using AutoMapper;
using Microsoft.EntityFrameworkCore;
using todolist_dotnet.Data;
using todolist_dotnet.Dtos;
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

        public async Task<ServiceResponse<List<GetTaskDto>>> AddTask(AddTaskDto newTask)
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            var task = _mapper.Map<TaskModel>(newTask);

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToListAsync();

            return serviceResponse;
        }

        public Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            var allTaskList = _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToListAsync();

            serviceResponse.Data = await allTaskList;

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var charById = await _context.Tasks.FirstOrDefaultAsync(t => t.ID == id);

            serviceResponse.Data = _mapper.Map<GetTaskDto>(charById);

            return serviceResponse;
        }

        public Task<ServiceResponse<GetTaskDto>> UpdateTask(int id)
        {
            throw new NotImplementedException();
        }
    }
}