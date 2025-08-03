using UserManagement.Domain.Repositories;
using UserManagement.Domain.Entities.Product;

namespace UserManagement.Application.UseCases.Product.CreateProduct
{
    public class CreateProductHandle
    {
        private readonly IProductRepository _productRepository;

        public CreateProductHandle(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<CreateProductResponse> Handle(CreateProductRequest request)
        {
            var existingProduct = await _productRepository.GetByName(request.Name);
            if (existingProduct != null)
            {
                throw new ApplicationException("Produto já cadastrado");
            }

            var product = new UserManagement.Domain.Entities.Product.Product(request.Name, request.Price, request.Stock);

            await _productRepository.AddAsync(product);

            return new CreateProductResponse(product.Id, product.Name, product.Price, product.Stock);
        }
        
    }
}