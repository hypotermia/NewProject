using Microsoft.EntityFrameworkCore;
using MiniProjects.Interfaces;
using MiniProjects.Models;

namespace MiniProjects.Repository
{
    public class ProductsRepository : IProductRepository
    {
        private readonly MasterServicesContext _dbContext;
        public ProductsRepository(MasterServicesContext context) {
            _dbContext = context;
        }
        
        public async Task AddTaskAsync(Product products)
        {
            var newProducts = new Product
            {
                Id = Guid.NewGuid(),
                ProductsName = products.ProductsName,
                ProductsPrices = products.ProductsPrices,
                Quantity = products.Quantity
            };
            _dbContext.Products.Add(newProducts);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteTaskAsync(Guid uId)
        {
            var prdk = await _dbContext.Products.FindAsync(uId);
            if (prdk == null)
            {
                return;
            }
            _dbContext.Products.Remove(prdk);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Product> GetTaskByIdAsync(Guid uId)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(u => u.Id == uId);

            if (product == null)
            {
                return null;
            }

            return new Product
            {
                Id = product.Id,
                ProductsName = product.ProductsName,
                ProductsPrices = product.ProductsPrices,
                Quantity = product.Quantity
            };
        }

        public async Task<IEnumerable<Product>> GetTasksAsync()
        {
            var _products = await _dbContext.Products.ToListAsync();
            return _products.Select(product => new Product
            {
                Id = product.Id,
                ProductsName = product.ProductsName,
                ProductsPrices = product.ProductsPrices,
                Quantity = product.Quantity,

            });
        }

        public async Task UpdateTaskAsync(Guid uId, Product products)
        {
            var existingProduct = await _dbContext.Products.FindAsync(uId);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.ProductsName = products.ProductsName;
            existingProduct.ProductsPrices = products.ProductsPrices;
            existingProduct.Quantity = products.Quantity;
            
            _dbContext.Products.Update(existingProduct);
            await _dbContext.SaveChangesAsync();
        }

    }
}

