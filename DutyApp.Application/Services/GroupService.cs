using DutyApp.Application.DTOs;
using DutyApp.Application.Interfaces;
using DutyApp.Domain.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DutyApp.Application.Services
{
  public class GroupService
  {
    private readonly IRepository<Group> _groupRepository;
    private readonly ILogger<GroupService> _logger;

    public GroupService(IRepository<Group> groupRepository, ILogger<GroupService> logger)
    {
      _groupRepository = groupRepository;
      _logger = logger;
    }

    public async System.Threading.Tasks.Task<GroupDto> CreateGroupAsync(GroupDto groupDto)
    {
      var group = new Group
      {
        Id = Guid.NewGuid(),
        Name = groupDto.Name,
        CreatorId = groupDto.CreatorId
      };

      await _groupRepository.AddAsync(group);

      groupDto.Id = group.Id;
      return groupDto;
    }

    public async System.Threading.Tasks.Task<IEnumerable<GroupDto>> GetGroupsAsync()
    {
      var groups = await _groupRepository.GetAllAsync();
      return groups.Select(g => new GroupDto
      {
        Id = g.Id,
        Name = g.Name,
        CreatorId = g.CreatorId
      });
    }

    public async System.Threading.Tasks.Task<GroupDto> GetGroupByIdAsync(Guid id)
    {
      var group = await _groupRepository.GetByIdAsync(id);
      if (group == null) return null;

      return new GroupDto
      {
        Id = group.Id,
        Name = group.Name,
        CreatorId = group.CreatorId
      };
    }

    public async System.Threading.Tasks.Task UpdateGroupAsync(GroupDto groupDto)
    {
      var group = await _groupRepository.GetByIdAsync(groupDto.Id);
      if (group != null)
      {
        group.Name = groupDto.Name;
        group.CreatorId = groupDto.CreatorId;

        await _groupRepository.UpdateAsync(group);
      }
      else
      {
        _logger.LogError($"Group with ID {groupDto.Id} not found.");
        throw new Exception($"Group with ID {groupDto.Id} not found.");
      }
    }

    public async System.Threading.Tasks.Task DeleteGroupAsync(Guid id)
    {
      var group = await _groupRepository.GetByIdAsync(id);
      if (group != null)
      {
        await _groupRepository.DeleteAsync(group);
      }
      else
      {
        _logger.LogError($"Group with ID {id} not found.");
        throw new Exception($"Group with ID {id} not found.");
      }
    }
  }
}
