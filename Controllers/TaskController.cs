using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using todolist_dotnet.Dtos.TaskDto;
using todolist_dotnet.Models;
using todolist_dotnet.Services.TaskService;

namespace todolist_dotnet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        // private readonly ITaskService _taskService;
        
        // public TaskController(ITaskService taskService)
        // {
        //     _taskService = taskService;
        // }

        // [HttpGet("GetAll")]
        // public async Task<ActionResult<ServiceResponse<GetTaskDto>>> GetSingle() 
        // {
        //     return Ok(await _taskService.GetTaskById());
        // }
    }
}