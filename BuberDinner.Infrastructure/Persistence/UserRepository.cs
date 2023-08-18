using BuberDinner.Application.Common.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Infrastructure.Persistence {
    internal class UserRepository : IUserRepository {
        private static readonly List<User> _users = new();
        public void AddUser(User user) {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email) {
            return _users.SingleOrDefault(user => user.Email == email);
        }
    }
}
