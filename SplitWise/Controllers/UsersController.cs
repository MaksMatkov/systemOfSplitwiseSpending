using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<UserResponse>> GetAll()
        {
            var users = await _userService.GetAsync();

            return _mapper.Map<List<User>, List<UserResponse>>(users.ToList());
        }

        [HttpGet("{id}")]
        public async Task<UserResponse> Get(int id)
        {
            var user = await _userService.GetByKeysAsync(id);

            return _mapper.Map<User, UserResponse>(user);
        }

        [HttpPost]
        public async Task<UserResponse> Post(UserRequest _user)
        {
            var user = await _userService.SaveAsync(_mapper.Map<UserRequest, User>(_user));

            return _mapper.Map<User, UserResponse>(user);
        }

        [HttpDelete("{id}")]
        public async Task<DataDeleteResponse> Delete(int id)
        {
            await _userService.DeleteAsync(id);

            return new DataDeleteResponse() { ok = true };
        } 

        [HttpPut()]
        public async Task<UserResponse> Put(UserRequest _user)
        {
            var result = await _userService.UpdateAsync(_mapper.Map<UserRequest, User>(_user), new object[] { _user.id });

            return _mapper.Map<User, UserResponse>(result);
        }

        [HttpGet("validateName/{name}")]
        public async Task<bool> IsNameUnique(string name)
        {
            return await _userService.IsUnique(name);
        }

    }
}
