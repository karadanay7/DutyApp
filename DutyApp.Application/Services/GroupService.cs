using DutyApp.Domain;

namespace DutyApp.Application;

public class GroupService
{
 private readonly IRepository<Group> _groupRepository;

        public GroupService(IRepository<Group> groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<GroupDto> CreateGroupAsync(GroupDto groupDto)
        {
            var group = new Group
            {
                Id = Guid.NewGuid(),
                Name = groupDto.Name,
                CreatorId = groupDto.CreatorId
            };

            await _groupRepository.AddAsync(group);
            return groupDto;
        }
}
