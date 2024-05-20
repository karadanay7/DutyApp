using DutyApp.Application.DTOs;
using DutyApp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DutyApp.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class TaskController : ControllerBase
  {
    private readonly TaskService _taskService;

    public TaskController(TaskService taskService)
    {
      _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
    }

    [HttpPost]
    public async Task<IActionResult> CreateTask([FromBody] TaskDto taskDto)
    {
      try
      {
        var createdTaskDto = await _taskService.CreateTaskAsync(taskDto);
        return CreatedAtAction(nameof(GetTaskById), new { id = createdTaskDto.Id }, createdTaskDto);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"An error occurred while creating the task: {ex.Message}");
      }
    }

    [HttpGet]
    public async Task<IActionResult> GetTasks()
    {
      try
      {
        var tasks = await _taskService.GetTasksAsync();
        return Ok(tasks);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"An error occurred while retrieving tasks: {ex.Message}");
      }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetTaskById(Guid id)
    {
      try
      {
        var task = await _taskService.GetTaskByIdAsync(id);
        if (task == null)
          return NotFound();

        return Ok(task);
      }
      catch (Exception ex)
      {
        return StatusCode(500, $"An error occurred while retrieving the task: {ex.Message}");
      }
    }

  }
}
