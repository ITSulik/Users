using Microsoft.EntityFrameworkCore;
using Users.Api.Infrastructure.Persistence;
using Users.Api.Infrastructure.Services.Joke.Options;
using Users.Api.Infrastructure.Services.Joke;
using Users.Api.Common.Interfaces.Service;

namespace Users.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddChuckNorrisJokeService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var options = new ChuckNorrisOptions();
        configuration.Bind(ChuckNorrisOptions.SectionName, options);

        services.AddHttpClient<IJokeService, ChuckNorrisJokeService>(client =>
        {
            client.BaseAddress = options.Host;
        });

        return services;
    }

    public static IServiceCollection AddDatabase(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<UsersDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("UsersDb")));

        return services;
    }
}

