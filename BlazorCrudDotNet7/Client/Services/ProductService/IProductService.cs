namespace BlazorCrudDotNet7.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        List<Category> Categories { get; set; }
        Task GetProducts();
        Task GetCategories();
        Task<Product?> GetProductById(int id);
        Task CreateProduct(Product product);
        Task UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
