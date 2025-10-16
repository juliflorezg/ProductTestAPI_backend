using ProductAPI_backend.DTOs;
using ProductAPI_backend.Models;
using ProductAPI_backend.Repository;

namespace ProductAPI_backend.Services
{
    public class ProductService(IRepository<Product, Guid> repository) : ICommonService<ProductDTO, ProductInsertDTO, ProductUpdateDTO, Guid>
    {

        private IRepository<Product, Guid> _productRepository = repository;
        public List<string> Errors { get; } = [];

        public async Task<IEnumerable<ProductDTO>> Get()
        {
            var products = await _productRepository.Get();
            return products.Select(product => new ProductDTO()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            });
        }

        public async Task<ProductDTO?> GetById(Guid id)
        {
            var product = await _productRepository.GetById(id);
            if (product != null)
            {
                var productDto = new ProductDTO()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };

                return productDto;
            }

            return null;
        }
        public async Task<ProductDTO> Add(ProductInsertDTO productInsertDto)
        {
            var product = new Product
            {
                Name = productInsertDto.Name,
                Price = productInsertDto.Price,
                Stock = productInsertDto.Stock
            };

            await _productRepository.Add(product);
            await _productRepository.Save();

            var productDto = new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock
            };

            return productDto;
        }
        public async Task<ProductDTO> Update(Guid id, ProductUpdateDTO productUpdateDto)
        {
            var product = await _productRepository.GetById(id);

            if (product != null)
            {
                product.Name = productUpdateDto.Name;
                product.Price = productUpdateDto.Price;
                product.Stock = productUpdateDto.Stock;

                _productRepository.Update(product);
                await _productRepository.Save();

                var productDto = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };

                return productDto;
            }
            return null;
        }

        public async Task<ProductDTO> Delete(Guid id)
        {
            var product = await _productRepository.GetById(id);

            if (product != null)
            {
                var productDto = new ProductDTO
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Stock = product.Stock
                };

                _productRepository.Delete(product);
                await _productRepository.Save();


                return productDto;
            }
            return null;
        }



        public bool Validate(ProductInsertDTO insertDto)
        {
            if (_productRepository.Search(p => p.Name.Equals(insertDto.Name)).Count() > 0)
            {
                Errors.Add("No se puede añadir un producto con el mismo nombre de uno existente.");
                return false;
            }
            return true;
        }

        public bool Validate(ProductUpdateDTO updateDto)
        {
            if (_productRepository.Search(
                p => p.Name.Equals(updateDto.Name) && !p.Id.Equals(updateDto.Id))
                    .Count() > 0)
            {
                Errors.Add("No puedo haber un producto con el mismo nombre de uno existente.");
                return false;
            }
            return true;
        }
    }
}

