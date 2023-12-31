﻿using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Commands {
    public interface IAuthenticationCommandService {
        // this is a command 
        ErrorOr<AuthenticationResult> Register(string FirstName, string LastName, string Email, string Password);
    }
}