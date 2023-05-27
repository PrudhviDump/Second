using AutoMapper;
using AutoMapper.Execution;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Second.Business_Logic_Layer.DTO;
using Second.Data_Access_Layer.Repository.Interface;
using Secondzz.Business_Logic_Layer.DTO;
using Secondzz.Data_Access_Layer.Models;
using Secondzz.Data_Access_Layer.Repository.Implementation;
using Secondzz.Data_Access_Layer.Repository.Interface;
using Secondzz.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Threading.Channels;
using System.Xml.Linq;
using System;
using static System.Collections.Specialized.BitVector32;

namespace Secondzz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProductRepo productRepo;



        //Creating Constructor
        public ProductController(IMapper mapper, IProductRepo productRepo)
        {
            this.mapper = mapper;
            this.productRepo = productRepo;
        }


        [HttpPost("AddProduct")]
        //[Authorize(Roles = "Admin")]


        public async Task<IActionResult> Create([FromBody] AddProductRequestDTO addProductRequestDTO)
        {
            //Map DTO to domain Model          
            var productentity = mapper.Map<Product>(addProductRequestDTO);
            await productRepo.CreateAsync(productentity);

            //Domain Model to DTO


            return Ok(mapper.Map<ProductDTO>(productentity));
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var QuestionEntity = await productRepo.GetAllAsync();

            return Ok(mapper.Map<List<ProductDTO>>(QuestionEntity));
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var questionn = await productRepo.GetByIdAsync(id);
            if (questionn == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductDTO>(questionn));

        }


        [HttpDelete]

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var entityDeleted = await productRepo.DeleteAsync(id);
            if (entityDeleted == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
       
    







            