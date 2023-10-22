using ECommerceAPI.Application.Abstractions.Storage;
using ECommerceAPI.Application.Features.Commands.ProductImageFile;
using ECommerceAPI.Application.Features.Commands.Products;
using ECommerceAPI.Application.Features.Queries.ProductImageFile;
using ECommerceAPI.Application.Features.Queries.Products;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Application.ViewModels.Products;
using ECommerceAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IFileReadRepository _fileReadRepository;
        private readonly IFileWriteRepository _fileWriteRepository;
        private readonly IProductImageFileReadRepository _productImageFileReadRepository;
        private readonly IProductImageFileWriteRepository _productImageFileWriteRepository;
        private readonly IInvoiceFileReadRepository _invoiceFileReadRepository;
        private readonly IInvoiceFileWriteRepository _invoiceFileWriteRepository;
        private readonly IOrderFileReadRepository _orderFileReadRepository;
        private readonly IOrderFileWriteRepository _orderFileWriteRepository;
        private readonly IStorageService _storageService;
        private readonly IConfiguration _configuration ;

        private readonly IMediator _mediator;

        public ProductsController(
            IProductWriteRepository productWriteRepository,
            IProductReadRepository productReadRepository,
            IWebHostEnvironment webHostEnvironment,
            IFileReadRepository fileReadRepository,
            IFileWriteRepository fileWriteRepository,
            IProductImageFileReadRepository productImageFileReadRepository,
            IProductImageFileWriteRepository productImageFileWriteRepository,
            IInvoiceFileReadRepository invoiceFileReadRepository,
            IInvoiceFileWriteRepository invoiceFileWriteRepository,
            IOrderFileReadRepository orderFileReadRepository,
            IOrderFileWriteRepository orderFileWriteRepository,
            IStorageService storageService,
            IConfiguration configuration,
            IMediator mediator)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
            _productImageFileReadRepository = productImageFileReadRepository;
            _productImageFileWriteRepository = productImageFileWriteRepository;
            _invoiceFileReadRepository = invoiceFileReadRepository;
            _invoiceFileWriteRepository = invoiceFileWriteRepository;
            _orderFileReadRepository = orderFileReadRepository;
            _orderFileWriteRepository = orderFileWriteRepository;
            _storageService = storageService;
            _configuration = configuration;
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
