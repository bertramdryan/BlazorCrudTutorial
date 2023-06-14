using BlazorCrudDotNet7.Shared;

namespace BlazorCrudDotNet7.Server.Services.ProductService
{
    public interface IProductService
    {
        Task<List<Product>?> GetProducts();
        Task<List<Category>?> GetCategories();
        Task<Product?> GetProductById(int id);
        Task<Product?> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int id);
        Task<Product?> CreateProduct(Product product);
    }
}
