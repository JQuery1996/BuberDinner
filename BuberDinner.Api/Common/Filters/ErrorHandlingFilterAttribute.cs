﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace BuberDinner.Api.Filters {
    public class ErrorHandlingFilterAttribute : ExceptionFilterAttribute {
        public override void OnException(ExceptionContext context) {
            if (context.Exception is null) {
                return;
            }

            var problemDetails = new ProblemDetails {
                Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
                Title = "An Error occurred while processing your request", Status = (int)HttpStatusCode.InternalServerError
            };
            //context.Result = new ObjectResult(problemDetails) { StatusCode = (int)HttpStatusCode.InternalServerError };

            context.Result = new ObjectResult(problemDetails);

            context.ExceptionHandled = true;
        }
    }
}