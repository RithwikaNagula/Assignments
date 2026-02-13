using ProductAPI.Dtos;

namespace ProductAPI.Services
{
    public interface IProductService
    {
        IEnumerable<ProductDTO> GetAllProducts();

        ProductDTO? GetProductById(int id);

        ProductDTO CreateProduct(ProductCreateDTO dto);

        bool UpdateProduct(int id, ProductUpdateDTO dto);

        bool DeleteProduct(int id);
    }
}
