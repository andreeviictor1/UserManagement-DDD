namespace UserManagement.Application.UseCases.GetIsers
{
    public record GetUsersResponse(Guid Id, string Nome, string Email, DateTime CreatedAt);
}
