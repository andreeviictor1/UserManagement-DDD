namespace UserManagement.Application.UseCases.Product.CreateProduct
{
    public record CreateProductRequest(string Name, decimal Price, int Stock);
}