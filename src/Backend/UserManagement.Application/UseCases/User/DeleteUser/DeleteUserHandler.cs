using UserManagement.Domain.Repositories;

namespace UserManagement.Application.UseCases.DeleteUser
{
    public class DeleteUserHandler
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task <DeleteUserResponse> Handle(DeleteUserRequest request)
        {
            var exists = await _userRepository.ExistsAsync(request.Id);

            if (!exists)
            {
                throw new ApplicationException("User not found");  
            }

            await _userRepository.DeleteAsync(request.Id);
            return new DeleteUserResponse(true);
        }
    }
}
