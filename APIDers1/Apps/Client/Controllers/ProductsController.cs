using ApiDers.Service.DTOs.Product;
using ApiDers.Service.Services.Abstractions;
using APIDers1.Service.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIDers1.Controllers.Apps
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await productService.GetAll();
            return StatusCode(res.StatusCode, res.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var res=await productService.GetById(id);
            return StatusCode(res.StatusCode, res.Data);

        }
       
        //[HttpPost]
        //public async Task<IActionResult> Create([FromForm]ProductPostDto dto)
        //{
        //    var res= await productService.Create(dto);
        //    return Ok(res);
        //}

        //[HttpPut("{id}")]
        //public async Task<IActionResult> Update(Guid id, ProductPutDto dto)
        //{
        //    var res = await productService.Update(id,dto);

        //    return StatusCode(res.StatusCode);
        //}


        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Remove(Guid id)
        //{
        //    var res = await productService.Remove(id);
        //    return StatusCode(res.StatusCode);
        //}

    }
}
