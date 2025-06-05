using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Infrastructure.Persistence;



var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddScoped<UserService>();
    builder.Services.AddDbContext<UsersDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDb")));
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();
