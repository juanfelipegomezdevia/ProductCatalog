using Microsoft.EntityFrameworkCore;
using ProductCatalog.Domain.Entities;
using ProductCatalog.Domain.Interfaces;
using ProductCatalog.Infrastructure.Context;

namespace ProductCatalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly CatalogDbContext _context;

        public ProductRepository(CatalogDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products
                .Where(p => p.Estado)
                .ToListAsync();
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .FirstOrDefaultAsync(p => p.Id == id && p.Estado);
        }

        public async Task<Product> CreateAsync(Product product)
        {
            product.FechaRegistro = DateTime.Now;
            product.Estado = true;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task UpdateAsync(Product product)
        {
            var existing = await _context.Products.FindAsync(product.Id);

            if (existing == null)
                return;

            existing.Nombre = product.Nombre;
            existing.Descripcion = product.Descripcion;
            existing.Categoria = product.Categoria;

            await _context.SaveChangesAsync();
           
        }

        public async Task DeleteAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                product.Estado = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Product>> SearchByNameAsync(string name)
        {
            return await _context.Products.AsNoTracking().Where(p => p.Estado && p.Nombre.Contains(name))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> SearchByCategoryAsync(string category)
        {
            return await _context.Products
                .Where(p => p.Categoria.Contains(category))
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> OrderByNameAsync()
        {
            return await _context.Products
                .Where(p => p.Estado)
                .OrderBy(p => p.Nombre)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> OrderByDateAsync()
        {
            return await _context.Products
                .Where(p => p.Estado)
                .OrderBy(p => p.FechaRegistro)
                .ToListAsync();
        }
    }
}