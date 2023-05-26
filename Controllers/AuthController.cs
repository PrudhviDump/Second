using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Secondzz.Data_Access_Layer.Models;
using Secondzz.Data_Access_Layer.Repository.Interface;
using Secondzz.Infrastructure;
using Secondzz.Business_Logic_Layer.DTO;
using Secondzz.Data_Access_Layer.Context;
using System.Security.Claims;


namespace Secondzz.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private SecondzzDbContext context;
        private readonly IConfiguration configuration;
        private readonly IMapper mapper;
        private readonly IUserRepo userRepo;

        public AuthController(SecondzzDbContext context, IConfiguration configuration, IMapper mapper, IUserRepo userRepo)
        {
            this.context = context;
            this.configuration = configuration;
            this.mapper = mapper;
            this.userRepo = userRepo;

        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(AddAuthUserLoginDTO loginModel)
        {

            var user = context.Users.Include(x => x.Role).SingleOrDefault(x => x.EmailId == loginModel.EmailId);

            if (user is null)
                return Unauthorized("Invalid Username or Password!");

            string hashedPassword = HashPassword(loginModel.Password);
            if (BCrypt.Net.BCrypt.Verify(loginModel.Password, user.Password))
            {

                var token = JWT.GenerateToken(new Dictionary<string, string> {
                { ClaimTypes.Role, user.Role.RoleName  },
                { "RoleId", user.Role.RoleId.ToString() },
                {JwtClaimTypes.PreferredUserName, user.UserName },
                { JwtClaimTypes.Id, user.UserId.ToString() },
                { JwtClaimTypes.Email, user.EmailId}
            }, configuration["JWT:Key"]);



                return Ok(new AddAuthResponseDTO { token = token, UserName = user.UserName });
            }
            else
            {
                return Unauthorized("Invalid Username or Password");
            }
        }
        [Route("Registration")]
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] AddUserRequestDTO addUserRequestDTO)
        {
            
            var userEntity = mapper.Map<User>(addUserRequestDTO);
            userEntity.Password = HashPassword(addUserRequestDTO.Password);
            await userRepo.CreateAsync(userEntity);
            // var users = mapper.Map<UserDTO>(userEntity);

            return Ok("Registration Successful");
        }
        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }
    }
}
