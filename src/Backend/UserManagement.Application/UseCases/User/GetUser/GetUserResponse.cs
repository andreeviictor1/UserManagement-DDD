namespace UserManagement.Application.UseCases.GetUser
{
    public record GetUserResponse(Guid Id, string Nome, string Email, DateTime CreatedAt);
}
