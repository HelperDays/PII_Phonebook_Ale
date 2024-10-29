using WhatsAppApiUCU;
using System;

namespace Library
{
    // Implementación del canal de WhatsApp que sigue la interfaz IMessageChannel
    public class WhatsAppChannel : IMessageChannel
    {
        // Método para enviar un mensaje a un contacto
        public void Send(Contact contact, Message message)
        {
            var whatsApp = new WhatsAppApi();
            try
            {
                // Envía el mensaje usando la API de WhatsApp
                whatsApp.Send(contact.Phone, message.Text);
                Console.WriteLine("Mensaje enviado exitosamente a " + contact.Name);
            }
            catch (Exception ex)
            {
                // Manejo de errores y logging del mensaje de excepción
                Console.WriteLine("Error al enviar el mensaje: " + ex.Message);
            }
        }
    }
}
