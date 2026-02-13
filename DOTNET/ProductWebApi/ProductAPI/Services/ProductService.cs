using ProductAPI.Dtos;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        //List of product category
        private static List<Category> _categories = new()
        {
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Clothing" }
        };
        //List of Products
        private static List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1000, CategoryId = 1 },
            new Product { Id = 2, Name = "Shirt", Price = 150, CategoryId = 2 }
        };

        public IEnumerable<ProductDTO> GetAllProducts()
        {
            return _products.Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
                CategoryName = _categories.FirstOrDefault(c => c.Id == p.CategoryId)?.Name ?? "Unknown"
            });
        }

        public ProductDTO? GetProductById(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null) return null;

            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                CategoryName = _categories.FirstOrDefault(c => c.Id == product.CategoryId)?.Name ?? "Unknown"
            };
        }

        public ProductDTO CreateProduct(ProductCreateDTO dto)
        {
           
            if (_products.Any(p => p.Name.ToLower() == dto.Name.ToLower()))
                throw new Exception("Product already exists.");

            var newProduct = new Product
            {
                Id = _products.Max(p => p.Id) + 1,
                Name = dto.Name,
                Price = dto.Price,
                CategoryId = dto.CategoryId
            };

            _products.Add(newProduct);

            return GetProductById(newProduct.Id)!;
        }

        public bool UpdateProduct(int id, ProductUpdateDTO dto)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null) return false;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.CategoryId = dto.CategoryId;

            return true;
        }

        public bool DeleteProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);

            if (product == null) return false;

            _products.Remove(product);
            return true;
        }
    }
}
