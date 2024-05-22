
using DutyApp.Application;
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
        
    }
}
