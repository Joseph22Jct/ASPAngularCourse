
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
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
            var users = await UserRepository.GetMembersAsync();

            
            return Ok(users);
            
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username){
            return await UserRepository.GetMemberAsync(username);

        }
    }
}