using E_commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text.Json.Serialization;

namespace E_commerce.Api.Dtos
{
    public class ProductToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public string ProductType { get; set; } = null!;
        public string Brand { get; set; } = null!;
    }
}
