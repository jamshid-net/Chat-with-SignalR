
using Chat.App.Blazor.Models;
using Microsoft.AspNetCore.SignalR;

namespace Chat.App.Blazor.Hubs;

public class ChatHub:Hub
{
  

    public async Task SendMessage(ChatRoom chatRoom)
    {
        await Clients.All.SendAsync("ReceiveMessage", chatRoom); 
       

    }

}

