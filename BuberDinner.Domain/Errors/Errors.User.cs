using ErrorOr;
namespace BuberDinner.Domain.Errors {
    public partial class Errors {
        public class User {
            public static Error DuplicateEmail = Error.Conflict(code: "User.DuplicateEmail", description: "Email is already in use.");
        }
    }
}
