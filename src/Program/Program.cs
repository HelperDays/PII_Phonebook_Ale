using System;
using Library;
using WhatsAppApiUCU;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la agenda y servicio de mensajes
            var phonebook = new Phonebook();
            var messageService = new MessageService(phonebook);

            // Crear y agregar contacto
            var contact = new Contact("Ale", "+598092989394", "alehernandezprincipal@gmail.com");
            phonebook.AddContact(contact);

            // Enviar mensaje vía WhatsApp
            var whatsappChannel = new WhatsAppChannel();
            messageService.SendMessage( new string[] {"Ale"} , "Aguante el café!", whatsappChannel);
        }
    }
}