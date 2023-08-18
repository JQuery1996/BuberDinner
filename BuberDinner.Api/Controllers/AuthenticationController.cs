
using AutoMapper;
using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers {
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        public AuthenticationController(IAuthenticationService _authenticationService, IMapper _mapper) {
            this._authenticationService = _authenticationService;
            this._mapper = _mapper;
        }

        [HttpPost("register", Name = "register")]
        public IActionResult Register(RegisterRequest request) {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);

            var response = _mapper.Map<AuthenticationResult>(authResult);
            return Ok(response);
        }

        [HttpPost("login", Name = "login")]
        public IActionResult Login(LoginRequest request) {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var response = _mapper.Map<AuthenticationResult>(authResult);
            return Ok(response);
        }
    }
}
