using AutoMapper;
using E_commerce.Api.Dtos;
using E_commerce.Domain.Contracts;
using E_commerce.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetAll()
        {
            // Eager-load Brand and Type
            var products = await _unitOfWork.Repository<Product>()
                .GetAllAsync(p => p.Brand, p => p.ProductType);

            var productDtos = _mapper.Map<IEnumerable<ProductToReturnDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductToReturnDto>> GetById(int id)
        {
            // Eager-load Brand and Type
            var products = await _unitOfWork.Repository<Product>()
                .GetAllAsync(p => p.Brand, p => p.ProductType);

            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null) return NotFound();

            var productDto = _mapper.Map<ProductToReturnDto>(product);
            return Ok(productDto);
        }
    }
}
