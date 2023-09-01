using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries {
    public class AuthenticationQueryService : IAuthenticationQueryService {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationQueryService(IJwtTokenGenerator _jwtTokenGenerator, IUserRepository _userRepository) {
            this._jwtTokenGenerator = _jwtTokenGenerator;
            this._userRepository = _userRepository;
        }
        public ErrorOr<AuthenticationResult> Login(string Email, string Password) {

            // 1. validate the user exists
            if (_userRepository.GetUserByEmail(Email) is not User user) {
                //throw new Exception("User with the given email doesn't exists.");
                return Errors.Authentication.InvalidAuthentication;
            }
            // 2. validate the password is correct
            if (user.Password != Password) {
                //throw new Exception("Invalid Password"); 
                return Errors.Authentication.InvalidAuthentication;
            }
            // 3. Create the JWT Token 
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
