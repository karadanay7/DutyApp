using DutyApp.Application.DTOs;
using DutyApp.Application.Interfaces;
using DutyApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutyApp.Application.Services
{
  public class TaskService
  {
    private readonly IRepository<Domain.Entities.Task> _taskRepository;

    public TaskService(IRepository<Domain.Entities.Task> taskRepository)
    {
      _taskRepository = taskRepository;
    }

    public async Task<TaskDto> CreateTaskAsync(TaskDto taskDto)
    {
      var task = new Domain.Entities.Task
      {
        Id = Guid.NewGuid(),
        Title = taskDto.Title,
        Description = taskDto.Description,
        Deadline = taskDto.Deadline,
        GroupId = taskDto.GroupId,
        CreatorId = taskDto.CreatorId
      };

      await _taskRepository.AddAsync(task);
      return taskDto;
    }

    public async Task<IEnumerable<TaskDto>> GetTasksAsync()
    {
      var tasks = await _taskRepository.GetAllAsync();
      return tasks.Select(t => new TaskDto
      {
        Id = t.Id,
        Title = t.Title,
        Description = t.Description,
        Deadline = t.Deadline,
        GroupId = t.GroupId,
        CreatorId = t.CreatorId
      });
    }

    public async Task<TaskDto> GetTaskByIdAsync(Guid id)
    {
      var task = await _taskRepository.GetByIdAsync(id);
      if (task == null) return null;

      return new TaskDto
      {
        Id = task.Id,
        Title = task.Title,
        Description = task.Description,
        Deadline = task.Deadline,
        GroupId = task.GroupId,
        CreatorId = task.CreatorId
      };
    }

    public async void UpdateTaskAsync(TaskDto taskDto)
    {
      var task = await _taskRepository.GetByIdAsync(taskDto.Id);
      if (task != null)
      {
        task.Title = taskDto.Title;
        task.Description = taskDto.Description;
        task.Deadline = taskDto.Deadline;
        task.GroupId = taskDto.GroupId;
        task.CreatorId = taskDto.CreatorId;

        await _taskRepository.UpdateAsync(task);
      }
    }


    public async void DeleteTaskAsync(Guid id)
    {
      var task = await _taskRepository.GetByIdAsync(id);
      if (task != null)
      {
        await _taskRepository.DeleteAsync(task); // Pass the task entity
      }
    }
  }
}
