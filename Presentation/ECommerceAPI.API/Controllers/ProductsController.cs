using ECommerceAPI.Application.Features.Commands.ProductImageFile;
using ECommerceAPI.Application.Features.Commands.Products;
using ECommerceAPI.Application.Features.Queries.ProductImageFile;
using ECommerceAPI.Application.Features.Queries.Products;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        private readonly IMediator _mediator;

        public ProductsController(
            
            IMediator mediator)
        {
            
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            GetAllProductQueryResponse response =  await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetProduct([FromRoute]GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommandRequest createProductCommandRequest)
        {

            CreateProductCommandResponse product = await _mediator.Send(createProductCommandRequest);

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody]UpdateProductCommandRequest updateProductCommandRequest)
        {
           UpdateProductCommandResponse response= await  _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]DeleteProductCommandRequest deleteProductCommandRequest) {

           DeleteProductCommandResponse repsonse = await _mediator.Send(deleteProductCommandRequest);
            return Ok();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery]UploadProductImageFileCommandRequest uploadProductImageFileCommandRequest)
        {
            uploadProductImageFileCommandRequest.Files = Request.Form.Files;
            await _mediator.Send(uploadProductImageFileCommandRequest);

            return Ok();
        }

        [HttpGet("[action]/{Id}")]
        public async Task<IActionResult> getProductImages([FromRoute]GetProductImageQueryRequest getProductImageQueryRequest)
        {
            List<GetProductImageQueryResponse> response = await _mediator.Send(getProductImageQueryRequest);
            
            return Ok(response);
        }

        [HttpDelete("[action]/{Id}")]
        public async Task<IActionResult> deleteProductImages([FromRoute] DeleteProductImageFileCommandRequest deleteProductImageFileCommandRequest, [FromQuery] string imageId)
        {
            deleteProductImageFileCommandRequest.ImageId = imageId;
           DeleteProductImageFileCommandResponse response =  await _mediator.Send(deleteProductImageFileCommandRequest);

            return Ok();
        }

    }
}
