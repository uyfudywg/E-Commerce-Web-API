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
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BrandController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Brand
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BrandToReturnDto>>> GetAll()
        {
            var brands = await _unitOfWork.Repository<Brand>().GetAllAsync();
            var brandDtos = _mapper.Map<IEnumerable<BrandToReturnDto>>(brands);
            return Ok(brandDtos);
        }

        // GET: api/Brand/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BrandToReturnDto>> GetById(int id)
        {
            var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(id);
            if (brand == null) return NotFound();

            var brandDto = _mapper.Map<BrandToReturnDto>(brand);
            return Ok(brandDto);
        }

        // GET: api/Brand/{id}/products
        [HttpGet("{id}/products")]
        public async Task<ActionResult<IEnumerable<ProductToReturnDto>>> GetProductsByBrand(int id)
        {
            // Ensure brand exists
            var brand = await _unitOfWork.Repository<Brand>().GetByIdAsync(id);
            if (brand == null) return NotFound();

            // Get products including Brand and Type
            var products = await _unitOfWork.Repository<Product>()
                .GetAllAsync(p => p.Brand, p => p.ProductType);

            var filtered = products.Where(p => p.BrandId == id);

            var productDtos = _mapper.Map<IEnumerable<ProductToReturnDto>>(filtered);
            return Ok(productDtos);
        }
    }
}
