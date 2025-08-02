using UserManagement.Domain.Repositories;

namespace UserManagement.Application.UseCases.UpdateUser
{
    public class UpdateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public UpdateUserHandler(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public async Task <UpdateUserResponse> Handle(UpdateUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                throw new ApplicationException("User not found");
            }

            if (user.Email != request.Email)
            {
                var existingUser = await _userRepository.GetByEmailAsync(request.Email);
                if(existingUser != null && existingUser.Id != request.Id)
                {
                    throw new ApplicationException("Email already in use");
                }
            }

            user.UpdateInfo(request.Nome, request.Email);
            await _userRepository.UpdateAsync(user);

            return new UpdateUserResponse(user.Id, user.Nome, user.Email, user.UpdatedAt!.Value);

        }

    }
}
