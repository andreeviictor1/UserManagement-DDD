namespace UserManagement.Application.UseCases.CreateUser
{
    public record CreateUserResponse(Guid Id, string Nome, string Email, DateTime CreatedAt);
}
