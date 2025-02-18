using Application.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<CreatedResult> CreateUser([FromBody] AddUserCommand addUserCommand)
        {
            var user = await _sender.Send(addUserCommand);
            return Created("/User", user);
        }
    }
}
