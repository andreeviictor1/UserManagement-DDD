using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Application.UseCases.CreateUser;
using UserManagement.Application.UseCases.DeleteUser;
using UserManagement.Application.UseCases.GetIsers;
using UserManagement.Application.UseCases.GetUser;
using UserManagement.Application.UseCases.GetUserEmail;
using UserManagement.Application.UseCases.UpdateUser;

namespace UserManagement.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CreateUserHandler _createUserHandler;
        private readonly GetUserHandler _getUserHandler;
        private readonly UpdateUserHandler _updateUserHandler;
        private readonly DeleteUserHandler _deleteUserHandler;
        private readonly GetUsersHandle _getUsersHandler;
        private readonly GetUserEmailHandler _getUserEmailHandler;


        public UserController (GetUsersHandle getUsersHandle, CreateUserHandler createUserHandler, 
            GetUserHandler getUserHandler, UpdateUserHandler updateUserHandler, 
            DeleteUserHandler deleteUserHandler,
            GetUserEmailHandler getUserEmailHandler)
        {
            _createUserHandler = createUserHandler;
            _getUserHandler = getUserHandler;
            _updateUserHandler = updateUserHandler;
            _deleteUserHandler = deleteUserHandler;
            _getUsersHandler = getUsersHandle;
            _getUserEmailHandler = getUserEmailHandler;
        }


        [HttpPost]
        public async Task<ActionResult<CreateUserResponse>> Create([FromBody] CreateUserRequest request)
        {
            try
            {
                var response = await _createUserHandler.Handle(request);
                return CreatedAtAction(nameof(GetById), new { id = response.Id }, response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpGet("{id}")]
        public async Task <ActionResult<GetUserResponse>> GetById(Guid id)
        {
            try
            {
                var response = await _getUserHandler.Handle(new GetUserRequest(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UpdateUserResponse>> Update(Guid id, [FromBody] UpdateUserDto dto)
        {
            try
            {
                var request = new UpdateUserRequest(id, dto.Nome, dto.Email);
                var response = await _updateUserHandler.Handle(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<DeleteUserResponse>> Delete(Guid id)
        {
            try
            {
                var response = await _deleteUserHandler.Handle(new DeleteUserRequest(id));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUsersResponse>>> GetAll()
        {
            try
            {
                var response = await _getUsersHandler.Handle(new GetUsersRequest());
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpGet("email")]
        public async Task<ActionResult<GetUserEmailResponse>> GetEmail(string email)
        {
            try
            {
                var response = await _getUserEmailHandler.Handle(new GetUserEmailRequest(email));
                return Ok(response);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}
