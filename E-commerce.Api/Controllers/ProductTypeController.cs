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
    public class ProductTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductTypeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/ProductType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductTypeToReturnDto>>> GetAll()
        {
            var types = await _unitOfWork.Repository<ProductType>().GetAllAsync();
            var typeDtos = _mapper.Map<IEnumerable<ProductTypeToReturnDto>>(types);
            return Ok(typeDtos);
        }

        // GET: api/ProductType/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductTypeToReturnDto>> GetById(int id)
        {
            var type = await _unitOfWork.Repository<ProductType>().GetByIdAsync(id);
            if (type == null) return NotFound();

            var typeDto = _mapper.Map<ProductTypeToReturnDto>(type);
            return Ok(typeDto);
        }

        // GET: api/ProductType/{id}/products
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProductsByType(int id)
        {
            // Ensure type exists
            var type = await _unitOfWork.Repository<ProductType>().GetByIdAsync(id);
            if (type == null) return NotFound();

            // Get all products including Brand and Type
            var products = await _unitOfWork.Repository<Product>()
                .GetAllAsync(p => p.Brand, p => p.ProductType);

            var filtered = products.Where(p => p.ProductTypeId == id);

            var productDtos = _mapper.Map<IEnumerable<ProductToReturnDto>>(filtered);
            return Ok(productDtos);
        }
    }
}
