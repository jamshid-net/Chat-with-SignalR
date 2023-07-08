using Chat.App.Blazor.Data;
using Chat.App.Blazor.Hubs;
using Chat.App.Blazor.Interfaces;
using Chat.App.Blazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;

namespace Chat.App.Blazor;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
     
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
      
        builder.Services.AddRazorPages();
        builder.Services.AddServerSideBlazor();
        builder.Services.AddDataConfiguration(builder.Configuration);
        builder.Services.AddSignalR();
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddMudServices(c => { c.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight; });
        builder.Services.AddScoped<ICurrentUser, CurrentUser>();
        builder.Services.ConfigureApplicationCookie(options =>
        {
            options.Cookie.HttpOnly = true;
            options.ExpireTimeSpan = TimeSpan.FromMinutes(10);

            options.LoginPath = "/Identity/Account/Login";
            // options.AccessDeniedPath = "/Identity/Account/AccessDenied";
            options.SlidingExpiration = true;

        });
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("RoleBasedClaim", policy => policy.RequireClaim("Permission", "true"));
        });
        builder.Services.AddResponseCompression(options =>
        {
            options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" });
        });

        var app = builder.Build();

        app.UseResponseCompression();
        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }
        app.UseHttpsRedirection();

        app.UseStaticFiles();
        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapBlazorHub();
        app.MapHub<ChatHub>("/chathub");
        app.MapFallbackToPage("/_Host");

        app.Run();
    }
}
