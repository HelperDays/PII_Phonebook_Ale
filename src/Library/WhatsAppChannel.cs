using WhatsAppApiUCU;

namespace Library;

public class WhatsAppChannel : IMessageChannel
{
    public void Send(Message message)
    {
        var whatsApp = new WhatsAppApi();
        whatsApp.Send("+598<Poné tu teléfono acá>", "Hey! I'm using WhatsApp");
    }
}