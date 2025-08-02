using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Repositories;

namespace UserManagement.Application.UseCases.GetIsers
{
    public class GetUsersHandle
    {
        private readonly IUserRepository _userRepository;
        public GetUsersHandle(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<GetUsersResponse>> Handle(GetUsersRequest request)
        {
            var users = await _userRepository.GetAllAsync();

            return users.Select(user => new GetUsersResponse(
                user.Id,
                user.Nome,
                user.Email,
                user.CreatedAt
            ));
        }
    }
}
