using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.UseCases.Product.CreateProduct;

namespace UserManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly CreateProductHandle _createProductHandle;

        public ProductController(CreateProductHandle  createProductHandle)
        {
            _createProductHandle = createProductHandle; 
        }

        [HttpPost]
        public async Task<ActionResult<CreateProductResponse>> Create([FromBody] CreateProductRequest request)
        {
            try
            {
                var response = await _createProductHandle.Handle(request);
                // return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}