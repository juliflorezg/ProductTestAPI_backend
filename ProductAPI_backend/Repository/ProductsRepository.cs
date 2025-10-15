using ProductAPI_backend.Models;

namespace ProductAPI_backend.Repository
{
    public class ProductsRepository : IRepository<Product>
    {

        public ProductsRepository(Context context)
        {
            _context = context;
        }

        private readonly Context _context;

        public Task<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Product?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Add(Product entity)
        {
            throw new NotImplementedException();
        }
        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product entity)
        {
            throw new NotImplementedException();
        }
        public Task Save()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Search(Func<Product, bool> filter)
        {
            throw new NotImplementedException();
        }

    }
}
