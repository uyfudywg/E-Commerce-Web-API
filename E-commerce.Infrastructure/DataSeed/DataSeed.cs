using E_commerce.Domain.Entities;
using E_commerce.Infrastructure.dbContext;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace E_commerce.Infrastructure.DataSeed
{
    public class DataSeed
    {

        public static void AddData(E_commerceContext e_CommerercrContext)
        {

            if (!e_CommerercrContext.Brands.Any())
            {
                var BrandsJson = File.ReadAllText("../E-commerce.Infrastructure/DataJason/brands.json");
                var Brands = JsonSerializer.Deserialize<List<Brand>>(BrandsJson);

                if (Brands?.Count > 0)
                {
                    e_CommerercrContext.Brands.AddRange(Brands);
                }
            }
            e_CommerercrContext.SaveChanges();


            if (!e_CommerercrContext.ProductTypes.Any())
            {
                var typesJson = File.ReadAllText("../E-commerce.Infrastructure/DataJason/types.json");
                var type = JsonSerializer.Deserialize<List<ProductType>>(typesJson);

                if (type?.Count > 0)
                {
                    e_CommerercrContext.ProductTypes.AddRange(type);
                }
            }
            e_CommerercrContext.SaveChanges();

            //if (!e_CommerercrContext.Products.Any())
            //{
            //    var productsJson = File.ReadAllText("../E-commerce.Infrastructure/DataJason/products.json");
            //    var products = JsonSerializer.Deserialize<List<Product>>(productsJson);

            //    if (products?.Count > 0)
            //    {
            //        foreach (var product in products)
            //        {
            //            // نحاول نجيب الـ Brand & ProductType من الداتا اللي موجودة
            //            var brand = e_CommerercrContext.Brands.FirstOrDefault(b => b.Id == product.BrandId);
            //            var type = e_CommerercrContext.ProductTypes.FirstOrDefault(t => t.Id == product.ProductTypeId);

            //            if (brand != null && type != null)
            //            {
            //                // نربط العلاقات
            //                product.BrandId = brand.Id;
            //                product.Brand = brand;

            //                product.ProductTypeId = type.Id;
            //                product.ProductType = type;

            //                e_CommerercrContext.Products.Add(product);
            //            }
            //        }

            //        e_CommerercrContext.SaveChanges();

            //    }

            //}

            if (!e_CommerercrContext.Products.Any())
            {
                var productsData = File.ReadAllText("../E-commerce.Infrastructure/DataJason/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                if (products != null && products.Count > 0)
                {
                    foreach (var product in products)
                    {
                        // تأكد إن الـ BrandId و ProductTypeId صالحين
                        var brandExists = e_CommerercrContext.Brands.Any(b => b.Id == product.BrandId);
                        var typeExists = e_CommerercrContext.ProductTypes.Any(t => t.Id == product.ProductTypeId);

                        if (brandExists && typeExists)
                        {
                            e_CommerercrContext.Products.Add(product);
                        }
                    }

                    e_CommerercrContext.SaveChanges();
                }
            }

        }
    }
}