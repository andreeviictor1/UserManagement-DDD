using UserManagement.Application.UseCases.GetUser;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.UseCases.GetUserEmail
{
    public class GetUserEmailHandler
    {
        private readonly IUserRepository _userRepository;
        public GetUserEmailHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<GetUserEmailResponse> Handle(GetUserEmailRequest request)
        {
            var user = await _userRepository.GetByEmailAsync(request.email);

            if (user == null)
            {
                throw new ApplicationException($"User with email not found.");
            }

            return new GetUserEmailResponse(user.Id, user.Nome, user.Email, user.CreatedAt);
        }

    }
}
