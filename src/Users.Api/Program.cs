using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Infrastructure.Persistence;
using Users.Api;



var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddChuckNorrisJokeService(builder.Configuration);
    builder.Services.AddScoped<UserService>();
    builder.Services.AddDatabase(builder.Configuration);
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();
