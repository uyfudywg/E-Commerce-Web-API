using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_commerce.Domain.Entities
{
   public class Product : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string PictureUrl { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public ProductType ProductType { get; set; } = null!;
        [JsonPropertyName("ProductBrandId")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; } = null!;


    }
}
