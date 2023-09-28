using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new(){Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name ="Product 1", Price = 100, Stock=10 },
                new(){Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name ="Product 2", Price = 200, Stock=20 },
                new(){Id = Guid.NewGuid(), CreatedDate = DateTime.UtcNow, Name ="Product 3", Price = 300, Stock=30 }
            });
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
