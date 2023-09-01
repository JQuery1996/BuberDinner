using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Application.Services.Authentication.Common;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Errors;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands {
    public class AuthenticationCommandService : IAuthenticationCommandService {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationCommandService(IJwtTokenGenerator _jwtTokenGenerator, IUserRepository _userRepository) {
            this._jwtTokenGenerator = _jwtTokenGenerator;
            this._userRepository = _userRepository;
        }
        public ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password) {

            // 1. validate the user dosen't exists 
            if (_userRepository.GetUserByEmail(Email) is not null) {
                //throw new DuplicateEmailException();
                //return new DuplicateEmailError();
                //return Result.Fail<AuthenticationResult>(new DuplicateEmailError());
                return Errors.User.DuplicateEmail;
                //throw new Exception("User with given email already exists.");
            }

            // 2. create user (generate unique ID) & persist to DB 
            var user = new User {
                FirstName = FirstName,
                LastName = LastName,
                Email = Email,
                Password = Password
            };
            _userRepository.AddUser(user);

            // 3. create JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }
    }
}
