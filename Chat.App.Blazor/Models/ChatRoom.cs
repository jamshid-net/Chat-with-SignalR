namespace Chat.App.Blazor.Models;

public class ChatRoom
{
    public Guid ChatRoomId { get; set; }
    public string Content { get; set; }
   
    public DateTime SentTime { get; set; }
    
    public string SenderId { get; set; }
    public virtual User? Sender { get; set; } =new User();
   
    public string ReceiverId { get; set; }
    public virtual User? Receiver { get; set; } = new User();
}
