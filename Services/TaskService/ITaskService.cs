using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using todolist_dotnet.Dtos.TaskDto;
using todolist_dotnet.Models;

namespace todolist_dotnet.Services.TaskService
{
    public interface ITaskService
    {
        Task<ServiceResponse<GetTaskDto>> GetTaskById(int id);
        Task<ServiceResponse<List<GetTaskDto>>> GetAllTasks();

    }
}