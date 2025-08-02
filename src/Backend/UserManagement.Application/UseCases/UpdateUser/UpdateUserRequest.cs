namespace UserManagement.Application.UseCases.UpdateUser
{
    public record UpdateUserRequest(Guid Id, string Nome, string Email);
}
