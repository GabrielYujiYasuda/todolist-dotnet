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

        public async Task<ServiceResponse<List<GetTaskDto>>> DeleteTask(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            var deletedTask = await _context.Tasks.FirstOrDefaultAsync(t => t.ID == id);

            if (deletedTask is null)
            {
                throw new Exception($"Task with ID: {id} not found.");
            }

            _context.Tasks.Remove(deletedTask);
            await _context.SaveChangesAsync();

            serviceResponse.Data = await _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToListAsync();;

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks()
        {
            var serviceResponse = new ServiceResponse<List<GetTaskDto>>();
            serviceResponse.Data = await _context.Tasks.Select(t => _mapper.Map<GetTaskDto>(t)).ToListAsync();;

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> GetTaskById(int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var charById = await _context.Tasks.FirstOrDefaultAsync(t => t.ID == id);

            serviceResponse.Data = _mapper.Map<GetTaskDto>(charById);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetTaskDto>> UpdateTask(UpdateTaskDto updatedTask, int id)
        {
            var serviceResponse = new ServiceResponse<GetTaskDto>();
            var taskById = await _context.Tasks.FirstOrDefaultAsync(t => t.ID == id);

            if (taskById is null)
            {
                throw new Exception($"Task with ID: {id} not found.");
            }

            taskById.Name = updatedTask.Name;
            taskById.Description = updatedTask.Description;
            taskById.IsComplete = updatedTask.IsComplete;

            await _context.SaveChangesAsync();

            var taskMapped = _mapper.Map<GetTaskDto>(taskById);

            serviceResponse.Data = taskMapped;

            return serviceResponse;
        }
    }
}