using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;

        public ProductRepository(StoreContext context)
        {
            _context=context;
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p =>p.ProductType)
                .SingleOrDefaultAsync(p => p.Id == id);
        }
        public async Task<IReadOnlyList<Product>> GetProducts()
        {
           return await _context.Products
                .Include(p => p.ProductBrand)
                .Include(p => p.ProductType)
                .ToListAsync();
        }
        public async Task<IReadOnlyList<ProductBrand>> GetProductsBrands()
        {
            return await _context.ProductBrands.ToListAsync();
        }
        public async Task<IReadOnlyList<ProductType>> GetProductsTypes()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
