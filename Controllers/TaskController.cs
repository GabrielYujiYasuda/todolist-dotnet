using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todolist_dotnet.Dtos;
using todolist_dotnet.Dtos.TaskDto;
using todolist_dotnet.Models;
using todolist_dotnet.Services.TaskService;

namespace todolist_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> GetAll() 
        {
            return Ok(await _taskService.GetAllTasks());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> GetTaskById(int id) 
        {
            return Ok(await _taskService.GetTaskById(id));
        }
        
        [HttpPost("Add")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> AddTask(AddTaskDto newTask) 
        {
            return Ok(await _taskService.AddTask(newTask));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetTaskDto>>> DeleteTask(int id)
        {
            var response = await _taskService.DeleteTask(id);

            if (response.Data is null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}