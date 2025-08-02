namespace UserManagement.Application.UseCases.UpdateUser
{
    public record UpdateUserResponse(Guid Id, string Nome, string Email, DateTime UpdatedAt);
    
}
