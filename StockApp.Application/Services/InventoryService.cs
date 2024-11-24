using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StockApp.API.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly List<Product> _products;

        public InventoryService()
        {
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Product A", Stock = 5, Price = 10 },
                new Product { Id = 2, Name = "Product B", Stock = 15, Price = 20 },
                new Product { Id = 3, Name = "Product C", Stock = 8, Price = 15 }
            };
        }

        public Task ReplenishStockAsync()
        {
            foreach (var product in _products.Where(p => p.Stock < 10))
            {
                product.Stock += 50;
            }
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold)
        {
            return Task.FromResult(_products.Where(p => p.Stock < threshold));
        }

        public Task<int> GetTotalStockValueAsync()
        {
            return Task.FromResult(_products.Sum(p => p.Stock * p.Price));
        }
    }

    public interface IInventoryService
    {
        Task ReplenishStockAsync();
        Task<IEnumerable<Product>> GetLowStockProductsAsync(int threshold);
        Task<int> GetTotalStockValueAsync();
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int Price { get; set; }
    }
}