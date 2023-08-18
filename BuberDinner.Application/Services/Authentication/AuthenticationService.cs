using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication {
    public class AuthenticationService : IAuthenticationService {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IJwtTokenGenerator _jwtTokenGenerator, IUserRepository _userRepository) {
            this._jwtTokenGenerator = _jwtTokenGenerator;
            this._userRepository = _userRepository;
        }
        public AuthenticationResult Login(string Email, string Password) {

            // 1. validate the user exists
            if (_userRepository.GetUserByEmail(Email) is not User user) {
                throw new Exception("User with the given email doesn't exists.");
            }
            // 2. validate the password is correct
            if (user.Password != Password) {
                throw new Exception("Invalid Password");
            }
            // 3. Create the JWT Token 
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Register(string FirstName, string LastName, string Email, string Password) {

            // 1. validate the user dosen't exists 
            if (_userRepository.GetUserByEmail(Email) is not null) {
                throw new Exception("User with given email is already exists.");
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
