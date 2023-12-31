﻿using BuberDinner.Application.Services.Authentication.Common;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication.Queries {
    public interface IAuthenticationQueryService {
        // this is a query
        ErrorOr<AuthenticationResult> Login(string Email, string Password);
    }
}