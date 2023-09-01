using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers {
    [Route("api/auth")]
    //[ErrorHandlingFilter]
    public class AuthenticationController : ApiController {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;
        public AuthenticationController(IMapper mapper, ISender mediator) {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost("register", Name = "register")]
        public async Task<IActionResult> Register(RegisterRequest request) {
            var registerCommand = _mapper.Map<RegisterCommand>(request);
            ErrorOr<AuthenticationResult> registerResult = await _mediator.Send(registerCommand);

            return registerResult.Match(
                result => Ok(_mapper.Map<AuthenticationResult>(result)),
               errors => Problem(errors)
            );
        }

        [HttpPost("login", Name = "login")]
        public async Task<IActionResult> Login(LoginRequest request) {
            var loginQuery = _mapper.Map<LoginQuery>(request);
            ErrorOr<AuthenticationResult> loginResult = await _mediator.Send(loginQuery);
            return loginResult.Match(result => Ok(_mapper.Map<AuthenticationResult>(result)), errors => Problem(errors));
        }
    }
}
