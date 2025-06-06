using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Hellang.Middleware.ProblemDetails;



var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<UserService>();
    builder.Services.AddDbContext<UsersDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDb")));
    builder.Services.AddControllers();
    builder.Services.AddProblemDetails(options =>
{
    options.IncludeExceptionDetails = (ctx, ex) => true;
    options.MapToStatusCode<NotFoundException>(StatusCodes.Status404NotFound);
    options.MapToStatusCode<ValidationException>(StatusCodes.Status400BadRequest);
});
    
}

var app = builder.Build();
{
    app.MapControllers();
    app.UseProblemDetails();
    app.UseStatusCodePages();
}

app.Run();
