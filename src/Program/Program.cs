using System;
using WhatsAppApiUCU;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            // Crear el contacto dueño
            var owner = new Contact("Owner_Ale", "+59892989394", "Alehernandezprincipal@gmail.com");

            // Crear la agenda con el dueño
            var phonebook = new Phonebook(owner);

            // Crear el servicio de mensajes
            var messageService = new MessageService(phonebook);

            // Crear y agregar un contacto a la agenda
            var contact1 = new Contact("Ale", "+59892989394", "Alehernandezprincipal@gmail.com");
            phonebook.AddContact(contact1);

            // Crear el canal de WhatsApp
            var whatsappChannel = new WhatsAppChannel();

            // Enviar mensaje al contacto
            messageService.SendMessage(new string[] { contact1.Name }, "Aguante el café", whatsappChannel);

            // Enviar mensaje al dueño
            messageService.SendMessage(new[] { owner.Name }, "Aguante el cafe", whatsappChannel);
            
            // Remover un contacto de la agenda
            phonebook.RemoveContact(contact1);
            Console.WriteLine($"El contacto {contact1.Name} ha sido removido de la agenda.");
        }
    }
}