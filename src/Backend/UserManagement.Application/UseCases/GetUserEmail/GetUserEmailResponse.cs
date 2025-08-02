namespace UserManagement.Application.UseCases.GetUserEmail
{
    public record GetUserEmailResponse(Guid Id, string Nome, string Email, DateTime CreatedAt);
}
