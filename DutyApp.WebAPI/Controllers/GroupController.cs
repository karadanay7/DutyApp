using DutyApp.Application.DTOs;
using DutyApp.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DutyApp.WebAPI.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class GroupController : ControllerBase
  {
    private readonly GroupService _groupService;

    public GroupController(GroupService groupService)
    {
      _groupService = groupService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] GroupDto groupDto)
    {
      var result = await _groupService.CreateGroupAsync(groupDto);
      return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetGroups()
    {
      var result = await _groupService.GetGroupsAsync();
      return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGroupById(Guid id)
    {
      var result = await _groupService.GetGroupByIdAsync(id);
      if (result == null) return NotFound();
      return Ok(result);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGroup(Guid id, [FromBody] GroupDto groupDto)
    {
      if (id != groupDto.Id) return BadRequest();
      await _groupService.UpdateGroupAsync(groupDto);
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGroup(Guid id)
    {
      await _groupService.DeleteGroupAsync(id);
      return NoContent();
    }
  }
}
