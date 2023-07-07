using Microsoft.AspNetCore.Identity;

namespace Chat.App.Blazor.Models;

public class User:IdentityUser
{

    public string FullName { get; set; } = string.Empty;
    public string? ProfilePicture { get; set; }
    public bool Status { get; set; } = false;

    public virtual List<ChatRoom>? SentMessages { get; set; }
    public virtual List<ChatRoom>? ReceivedMessages { get; set; }
    public virtual List<Contact>? Contacts { get; set; }
}
