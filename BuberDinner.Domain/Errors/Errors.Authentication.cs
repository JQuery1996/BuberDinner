using ErrorOr;
namespace BuberDinner.Domain.Errors {
    public partial class Errors {
        public class Authentication {
            public static Error InvalidAuthentication = Error.Validation(code: "Auth.InvalidCredentials", description: "Invalid Credentials.");
        }
    }
}
