using Chat.App.Blazor.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Chat.App.Blazor.Data;

public static class DataConfiguration
{
    public static IServiceCollection AddDataConfiguration(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseLazyLoadingProxies();
            options.UseNpgsql(configuration.GetConnectionString("DbConnection"));
        });

        services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
          .AddRoles<IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();


        return services;
    }
}
