
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController: BaseAPIController
    {
        
        public IUserRepository UserRepository { get; }

        public UsersController(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
            
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers(){
            var users = (await UserRepository.GetUsersAsync());

            var usersToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            
            return Ok(usersToReturn);
            
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUser(string username){
            var user = UserRepository.GetUserByUsernameAsync(username);

            return _mapper.Map<MemberDto>(user);
        }
    }
}