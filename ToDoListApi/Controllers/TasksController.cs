using Microsoft.AspNetCore.Mvc;
using OLA1_SofQuality.ToDoListApi.Services;
using OLA1_SofQuality.ToDoListApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace OLA1_SofQuality.ToDoListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoTask>>> GetTasks()
        {
            var tasks = await _taskService.GetTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoTask>> GetTask(int id)
        {
            var task = await _taskService.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(ToDoTask task)
        {
            var addedTask = await _taskService.AddTaskAsync(task);
            return Ok(addedTask);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTask(ToDoTask task)
        {
            await _taskService.UpdateTaskAsync(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return NoContent();
        }
    }
}