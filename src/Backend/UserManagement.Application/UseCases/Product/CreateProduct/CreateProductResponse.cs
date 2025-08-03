namespace UserManagement.Application.UseCases.Product.CreateProduct
{
    public record CreateProductResponse(Guid Id, string Name, decimal Price, int Stock);
}