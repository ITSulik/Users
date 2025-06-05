using Users.Api.Services;
using Microsoft.EntityFrameworkCore;
using Users.Api.Infrastructure.Persistence;



var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddHttpClient<ChuckService>("ChuckNorris", client =>
{
    client.BaseAddress = new Uri("https://api.chucknorris.io/");
});
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
