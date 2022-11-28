using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SplitWise.API.Helpers;
using SplitWise.API.Models;
using SplitWise.BusinessLogic.Abstraction;
using SplitWise.BusinessLogic.CustomExceptions;
using SplitWise.Domain.Enteties;
using SplitWise.Domain.Models;
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
        private readonly IExpensesService _expenseService;
        private readonly IMapper _mapper;

        public GroupsController(IGroupService groupService, IMapper mapper, IExpensesService expenseService)
        {
            _groupService = groupService;
            _mapper = mapper;
            _expenseService = expenseService;
        }

        [HttpGet("usersGroup")]
        [Authorize]
        public async Task<List<GroupResponse>> GetAllbyUser()
        {
            var groups = await _groupService.GetAllByUserAsync(IdentityHelper.GetSub(User));

            return _mapper.Map<List<Group>, List<GroupResponse>>(groups.ToList());
        }

        [HttpGet("{groupId}")]
        [Authorize]
        public async Task<GroupResponse> Get(int groupId)
        {
            var groups = await _groupService.GetSecureAsync(groupId, IdentityHelper.GetSub(User));

            return _mapper.Map<Group, GroupResponse>(groups);
        }

        [HttpGet("{groupId}/Statistic")]
        [Authorize]
        public async Task<CalculatedData> GetStatistic(int groupId)
        {
            var userId = IdentityHelper.GetSub(User);
            return await _expenseService.GetCalculatedDataAsync(userId, groupId);
        }

        [HttpPost]
        [Authorize]
        public async Task<GroupResponse> Post(GroupRequest _group)
        {
            var newGroup = await _groupService.SaveAsync(_mapper.Map<GroupRequest, Group>(_group));
            
            //add creator to group
            await _groupService.AddFirstUserToGroup(IdentityHelper.GetSub(User), newGroup.Id);

            return _mapper.Map<Group, GroupResponse>(newGroup);
        }

        [HttpPost("{groupId}/users/{userId}")]
        [Authorize]
        public async Task<UserResponse> AddUserToGroup(int groupId, int userId)
        {
            return _mapper.Map<User, UserResponse>(await _groupService.AddNewUserToGroup(IdentityHelper.GetSub(User), userId, groupId));
        }

        [HttpGet("{groupId}/users")]
        [Authorize]
        public async Task<List<UserResponse>> GetUsers(int groupId)
        {
            return _mapper.Map<List<User>, List<UserResponse>>(await _groupService.GetGroupMembersAsync(groupId, IdentityHelper.GetSub(User)));
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<DataDeleteResponse> Delete(int id)
        {
            await _groupService.DeleteAsync(id);

            return new DataDeleteResponse() { ok = true };
        }
    }
}
