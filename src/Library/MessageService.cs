using System.Collections.Generic;

namespace Library
{
    public class MessageService
    {
        private readonly Phonebook phonebook;

        public MessageService(Phonebook phonebook)
        {
            this.phonebook = phonebook;
        }

        public void SendMessage(string[] names, string content, IMessageChannel channel)
        {
            // Buscar los contactos según los nombres proporcionados
            var contacts = phonebook.Search(names);

            foreach (var contact in contacts)
            {
                // Validación para confirmar datos de contacto
                if (contact.Phone == null && channel is WhatsAppChannel)
                {
                    System.Console.WriteLine($"El contacto {contact.Name} no tiene número de teléfono.");
                    continue;
                }
                if (contact.Email == null && !(channel is WhatsAppChannel))
                {
                    System.Console.WriteLine($"El contacto {contact.Name} no tiene correo electrónico.");
                    continue;
                }

                // Crear el mensaje
                var message = new Message(contact.Name, contact.Phone, content);
                
                // Enviar el mensaje e imprimir log de depuración
                System.Console.WriteLine($"Enviando mensaje a {contact.Name}...");
                channel.Send(contact, message);
                System.Console.WriteLine($"Mensaje enviado a {contact.Name} a través de {channel.GetType().Name}");
            }
        }
    }
}