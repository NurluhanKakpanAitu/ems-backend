using Application.Interfaces;
using Domain.Entity.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Persistence.Data;
using Persistence.Repos;

namespace Persistence;

public static class ServiceRegistration
{
    public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });
        services.AddScoped(typeof(IQueryRepository<>), typeof(EfReadonlyRepository<>));
        services.AddScoped(typeof(IAsyncRepository<>), typeof(EfAsyncRepository<>));

        services.AddIdentity<AppUser, IdentityRole>(conf =>
            {
                conf.Password.RequireDigit = false;
                conf.Password.RequiredLength = 6;
                conf.Password.RequireLowercase = false;
                conf.Password.RequireUppercase = false;
                conf.Password.RequireNonAlphanumeric = false;
                conf.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

        services.ConfigureApplicationCookie(conf =>
        {
            conf.Cookie.Name = "IdentityServer.Cookie";
            conf.LoginPath = "/Account/Login";
            conf.LogoutPath = "/Account/Logout";   
        });

        services.AddIdentityServer()
            .AddInMemoryApiResources(Config.GetApiResources())
            .AddInMemoryApiScopes(Config.GetApiScopes())
            .AddInMemoryClients(Config.GetClients())
            .AddInMemoryIdentityResources(Config.GetIdentityResources())
            .AddDeveloperSigningCredential()
            .AddAspNetIdentity<AppUser>();

        NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
    }
}