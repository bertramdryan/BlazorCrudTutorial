using BlazorCrudDotNet7.Server.Data;
using BlazorCrudDotNet7.Shared;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrudDotNet7.Server.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly DataContext _context;

        public ProductService(DataContext context)
        {
            _context = context;
        }

        public async Task<Product?> CreateProduct(Product product)
        {

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Product?> GetProductById(int id)
        {
            var product = await _context.Products.FindAsync(id);

            return product;
        }

        public async Task<List<Product>?> GetProducts()
        {
            var products = await _context.Products.Include(p => p.Category).ToListAsync();
            

            return products;
        }

        public async Task<List<Category>?> GetCategories()
        {
            var categories = await _context.Categories.ToListAsync();
            return categories;
        }

        public async Task<Product?> UpdateProduct(Product product)
        {

            _context.Products.Update(product);

            await _context.SaveChangesAsync();


            return product;
        }
    }
}
