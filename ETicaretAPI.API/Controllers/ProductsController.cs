using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

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
                new() { Id = Guid.NewGuid(), Name="Product_2", Price=600, CreatedDate = DateTime.UtcNow, Stock=60 },
                new() { Id = Guid.NewGuid(), Name="Product_3", Price=700, CreatedDate = DateTime.UtcNow, Stock=70 },
                new() { Id = Guid.NewGuid(), Name="Product_4", Price=800, CreatedDate = DateTime.UtcNow, Stock=80 },
                new() { Id = Guid.NewGuid(), Name="Product_5", Price=900, CreatedDate = DateTime.UtcNow, Stock=90 },
            });
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }
    }
}

