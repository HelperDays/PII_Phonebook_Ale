using WhatsAppApiUCU;
using System;

namespace Library
{
    public class WhatsAppChannel : IMessageChannel
    {
        public void Send(Contact contact, Message message)
        {
            var whatsApp = new WhatsAppApi();
            try
            {
                whatsApp.Send(contact.Phone, message.Text);
                Console.WriteLine("Mensaje enviado exitosamente a " + contact.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al enviar el mensaje: " + ex.Message);
            }
        }
    }
}
