using System.Collections.Generic;

namespace Library
{
    // Clase que proporciona servicios de mensajes utilizando una agenda
    public class MessageService
    {
        private readonly Phonebook _phonebook;

        // Constructor que inicializa el servicio con una agenda
        public MessageService(Phonebook phonebook)
        {
            this._phonebook = phonebook;
        }

        // Método para enviar mensajes a contactos por nombres
        public void SendMessage(string[] names, string content, IMessageChannel channel)
        {
            // Buscar los contactos según los nombres proporcionados
            var contacts = _phonebook.Search(names);
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