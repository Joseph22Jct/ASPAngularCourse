
using API.Data;
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
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
            return Ok(await UserRepository.GetUsersAsync());
            
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUser(string username){
            return await UserRepository.GetUserByUsernameAsync(username);
        }
    }
}