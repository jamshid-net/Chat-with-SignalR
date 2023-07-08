using Chat.App.Blazor.Interfaces;
using System.Security.Claims;

namespace Chat.App.Blazor.Services;


public class CurrentUser : ICurrentUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserId => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public string? UserProfilePicture => _httpContextAccessor.HttpContext?.User?.FindFirstValue("ProfilePicture");
}
