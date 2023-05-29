using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second.Business_Logic_Layer.DTO;
using Second.Data_Access_Layer.Models;
using Second.Data_Access_Layer.Repository.Interface;
using Secondzz.Data_Access_Layer.Models;

namespace Second.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductRepo chatRepo;
        //Creating Constructor
        public ChatController(IMapper mapper, IChatRepo chatRepo)
        {
            this.mapper = mapper;
            this.chatRepo = chatRepo;
        }

        [AllowAnonymous]
        [HttpPost("Send Chat")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] AddChatDTO addChatDTO)
        {
            //Map DTO to domain Model          
            var chatentity = mapper.Map<Chat>(addChatDTO);
            await chatRepo.CreateAsync(chatentity);

            //Domain Model to DTO


            return Ok(mapper.Map<ChatDTO>(chatentity));
        }

        [AllowAnonymous]
        [HttpGet]
        //[Authorize(Roles = )]
        public async Task<ActionResult<IEnumerable<ChatDTO>>> GetAll()
        {
            var Chatentity = await chatRepo.GetAllAsync();

            return Ok(mapper.Map<List<ChatDTO>>(Chatentity));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var chatt = await chatRepo.GetByIdAsync(id);
            if (chatt == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ChatDTO>(chatt));

        }


        [HttpDelete]

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entityDeleted = await chatRepo.DeleteAsync(id);
            if (entityDeleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
