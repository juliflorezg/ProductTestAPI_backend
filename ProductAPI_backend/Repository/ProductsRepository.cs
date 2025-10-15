using ProductAPI_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace ProductAPI_backend.Repository
{
    public class ProductsRepository : IRepository<Product, Guid>
    {

        public ProductsRepository(Context context)
        {
            _context = context;
        }

        private readonly Context _context;

        public async Task<IEnumerable<Product>> Get() => await _context.Products.ToListAsync();

        public async Task<Product?> GetById(Guid id) => await _context.Products.FindAsync(id);

        public async Task Add(Product entity) => await _context.AddAsync(entity);
        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.Products.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(Product entity) => _context.Products.Remove(entity);
        public Task Save() => _context.SaveChangesAsync();

        public IEnumerable<Product> Search(Func<Product, bool> filter) => _context.Products.Where(filter).ToList();

    }
}
