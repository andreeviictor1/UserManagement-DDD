using UserManagement.Domain.Entities.User;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.UseCases.CreateUser
{
    public class CreateUserHandler
    {
        private readonly IUserRepository _userRepository;

        public CreateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<CreateUserResponse> Handle(CreateUserRequest request)
        {
            // Verificar se email já existe
            var existingUser = await _userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
                throw new ApplicationException("Email já está em uso");

            // Criar usuário
            var user = new User(request.Nome, request.Email, request.Password);

            // Salvar no repositório
            await _userRepository.AddAsync(user);

            return new CreateUserResponse(user.Id, user.Nome, user.Email, user.CreatedAt);
        }
    }
}
