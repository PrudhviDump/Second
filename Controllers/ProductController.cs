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

       // [AllowAnonymous]
        [HttpPost("AddProduct")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> Create([FromBody] AddProductRequestDTO addProductRequestDTO)
        {
            //Map DTO to domain Model          
            var productentity = mapper.Map<Product>(addProductRequestDTO);
            await productRepo.CreateAsync(productentity);

            //Domain Model to DTO


            return Ok(mapper.Map<ProductDTO>(productentity));
        }

        [AllowAnonymous]
        [HttpGet]
        //[Authorize(Roles = )]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetAll()
        {
            var Productentity = await productRepo.GetAllAsync();

            return Ok(mapper.Map<List<ProductDTO>>(Productentity));
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var productt = await productRepo.GetByIdAsync(id);
            if (productt == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProductDTO>(productt));

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

        [HttpPut]
        [Route("{id:int}/admin")]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> ValidateProduct([FromRoute] int id, ProductValidDTO status)
        {
            var contentEntity = mapper.Map<Product>(status);
            contentEntity = await productRepo.UpdateStatus(id, contentEntity);
            if (contentEntity == null)
            {
                return BadRequest();
            }



            return Ok(mapper.Map<ProductDTO>(contentEntity));
        }
    }
}