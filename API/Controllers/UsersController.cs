using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Data;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using AutoMapper;
using API.DTOs;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users =  await _userRepository.GetUsersAsync();
            var usersToReturn =  _mapper.Map<IEnumerable<BaseUserDto>>(users);
            return Ok(usersToReturn) ;
        }

        [Authorize (Roles = "User")]
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }

    }
}