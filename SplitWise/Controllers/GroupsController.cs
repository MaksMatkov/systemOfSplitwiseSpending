using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitWise.API.Helpers;
using SplitWise.API.Models;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SplitWise.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupsController : ControllerBase
    {
        private readonly IGroupService _groupService;
        private readonly IMapper _mapper;

        public GroupsController(IGroupService groupService, IMapper mapper)
        {
            _groupService = groupService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<GroupResponse>> GetAll()
        {
            var groups = await _groupService.GetAsync();

            return _mapper.Map<List<Group>, List<GroupResponse>>(groups.ToList());
        }

        [HttpPost]
        [Authorize]
        public async Task<GroupResponse> Post(GroupRequest _group)
        {
            var newGroup = await _groupService.SaveAsync(_mapper.Map<GroupRequest, Group>(_group));
            //add creator to group
            await _groupService.AddUserToGroup(IdentityHelper.GetSub(User), newGroup.Id);

            return _mapper.Map<Group, GroupResponse>(newGroup);
        }

        [HttpPost("{groupId}/users/{userId}")]
        [Authorize]
        public async Task<bool> AddUserToGroup(int groupId, int userId)
        {
            var group = await _groupService.GetByKeysAsync(groupId);
            if(group == null)
                throw new EntityNotFoundException("The Group cannot be found.", groupId);

            if(!(await _groupService.IsMemberOfGroup(userId, groupId)))
                throw new ForbiddenException("You are not member of this group!");

            await _groupService.AddUserToGroup(IdentityHelper.GetSub(User), group.Id);

            return true;
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DataDeleteResponse> Delete(int id)
        {
            var item = await _groupService.GetByKeysAsync(id);
            if (item == null)
                throw new EntityNotFoundException("Group Not Found!", id);

            await _groupService.DeleteAsync(item);

            return new DataDeleteResponse() { ok = true };
        }
    }
}
