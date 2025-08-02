using UserManagement.Domain.Repositories;

namespace UserManagement.Application.UseCases.GetUser
{
    public class GetUserHandler
    {
        private readonly IUserRepository _userRepository;

        public GetUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);

            if (user == null)
            {
                throw new ApplicationException($"User with ID {request.Id} not found.");
            }

            return new GetUserResponse(user.Id, user.Nome, user.Email, user.CreatedAt);
        }

    }
}
