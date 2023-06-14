using BlazorCrudDotNet7.Shared;
using Microsoft.AspNetCore.Components;
using System.Net;
using System.Net.Http.Json;

namespace BlazorCrudDotNet7.Client.Services.ProductService
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _http;
        private readonly NavigationManager _navigationManager;

        public ProductService(HttpClient http, NavigationManager navigationManager)
        {
            _http = http;
            _navigationManager = navigationManager;
        }

        public List<Product> Products { get; set; } = new List<Product>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public async Task CreateProduct(Product product)
        {
            await _http.PostAsJsonAsync("api/product", product);
            _navigationManager.NavigateTo("/products");
        }

        public async Task DeleteProduct(int id)
        {
            await _http.DeleteAsync($"api/product/{id}");
            _navigationManager.NavigateTo("/products");
        }

        public async Task<Product?> GetProductById(int id)
        {
            var result = await _http.GetAsync($"api/product/{id}");


            if (result.StatusCode == HttpStatusCode.OK)
            {
                return await result.Content.ReadFromJsonAsync<Product?>();
            }

            return null;
        }

        public async Task GetProducts()
        {
            var result = await _http.GetFromJsonAsync<List<Product>>("api/product");
            if (result is not null)
            { 
                Products = result.ToList();
                await GetCategories();
            }
               
        }

        public async Task GetCategories()
        {
            var result = await _http.GetFromJsonAsync<List<Category>>("api/category");
            if (result is not null)
                Categories = result.ToList();
        }

        public async Task UpdateProduct(Product product)
        {
            await _http.PutAsJsonAsync("api/product", product);
            _navigationManager.NavigateTo("/products");
        }
    }
}
