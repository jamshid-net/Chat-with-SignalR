namespace Chat.App.Blazor.Interfaces;

public interface ICurrentUser
{
    string? UserId { get; }
    string? UserProfilePicture { get; }

}