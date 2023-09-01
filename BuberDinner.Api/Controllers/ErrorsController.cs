//using BuberDinner.Application.Common.Errors;
//using Microsoft.AspNetCore.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//namespace BuberDinner.Api.Controllers {
//    [ApiController]
//    public class ErrorsController : ControllerBase {
//        [Route("/errors")]
//        public IActionResult Error() {
//            // getting the error from the HttpContext
//            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//            var (statusCode, message) = exception switch {
//                IServiceException serviceException => ((int)serviceException.statusCode, serviceException.ErrorMessage),
//                _ => (StatusCodes.Status500InternalServerError, "An unexpected error happened")
//            };
//            return Problem(statusCode: statusCode, title: message);
//        }
//    }
//}
