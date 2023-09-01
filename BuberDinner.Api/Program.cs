using BuberDinner.Api;
using BuberDinner.Api.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args); {
    //builder.Services.AddControllers(options => {
    //    options.Filters.Add<ErrorHandlingFilterAttribute>();
    //});
    builder.Services.AddControllers();
    // Dependency Injection from other Layers
    builder.Services.AddPresentation()
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    // configure AutoMapper
    //builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

    builder.Services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();
}

var app = builder.Build(); {
    // So, this is the first approach.
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    //app.UseExceptionHandler("/errors");
    app.UseHttpsRedirection();
    //app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
