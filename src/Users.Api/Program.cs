using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Data;



var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddDbContext<UsersDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("UsersDB")));
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.MapControllers();
}

app.Run();
