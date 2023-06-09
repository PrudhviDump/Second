﻿using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Secondzz.Business_Logic_Layer.DTO;
using Secondzz.Data_Access_Layer.Models;
using Secondzz.Data_Access_Layer.Repository.Interface;


namespace Secondzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class UserController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IUserRepo userRepo;
        //private readonly IApplicationRepo applicationRepo;

        public UserController(IMapper mapper, IUserRepo userRepo)
        {
            this.mapper = mapper;
            this.userRepo = userRepo;
           // this.applicationRepo = applicationRepo;
        }

        //Create User
        //Post:/api/users        


        //GET Walks        //GET:/api/walks       
        [HttpGet]
        [Route("admin")]
        [Authorize(Roles = "Admin")]

        public async Task<ActionResult<IEnumerable<UserDTO>>> GetAll()
        {
            var userEntity = await userRepo.GetAllAsync();

            return Ok(mapper.Map<List<UserDTO>>(userEntity));
        }

        [HttpGet]
        [Route("{id:int}/admin")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var userEntity = await userRepo.GetByIdAsync(id);
            if (userEntity == null)
            {
                return NotFound();
            }
            var users = mapper.Map<UserDTO>(userEntity);
            return Ok(users);

        }

        /*[HttpPut]
        [Route("{id:int}")]


        public async Task<IActionResult> Update([FromRoute] int id, UpdateUserRequestDTO updateUserRequestDTO)
        {
            var userEntity = mapper.Map<User>(updateUserRequestDTO);
            userEntity = await userRepo.UpdateAsync(id, userEntity);
            if (userEntity == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UserDTO>(userEntity));
        }*/

        [HttpDelete]
        [Route("{Userid:int}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int Userid)
        {
            var entityDeleted = await userRepo.DeleteAsync(Userid);
            if (entityDeleted == null)
            {
                return NotFound();
            }

            return Ok("Deleted the user");
        }
    }
}
