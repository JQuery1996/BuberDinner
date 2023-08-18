using BuberDinner.Api.Helper;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

var builder = WebApplication.CreateBuilder(args); {
    builder.Services.AddControllers();
    // Dependency Injection from other Layers
    builder.Services.AddApplication().AddInfrastructure(builder.Configuration);
    // configure AutoMapper
    builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
}

var app = builder.Build(); {
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}
