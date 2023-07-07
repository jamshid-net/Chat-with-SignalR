﻿namespace Chat.App.Blazor.Models;

public class Contact
{
    public Guid ContactId { get; set; }
    public string UserId { get; set; }
    public virtual User? User { get; set; }

    public string FriendId { get; set; }    
    public virtual User? Friend { get; set; }

  
}
