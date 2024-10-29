using System.Collections.Generic;
using System.Linq;

namespace Library
{
    // Clase que representa una agenda de contactos
    public class Phonebook
    {
        private List<Contact> persons;

        // Constructor que inicializa la agenda con un dueño
        public Phonebook(Contact owner)
        {
            this.Owner = owner;
            this.persons = new List<Contact>();
        }

        // Propiedad para acceder a la lista de contactos
        public List<Contact> Contacts => persons;

        // Propiedad para el dueño de la agenda
        public Contact Owner { get; set; }

        // Método para agregar un contacto a la lista
        public void AddContact(Contact contact)
        {
            if (contact != null && !persons.Contains(contact))
            {
                persons.Add(contact);
            }
        }

        // Método para remover un contacto de la lista
        public void RemoveContact(Contact contact)
        {
            persons.Remove(contact);
        }

        // Método para buscar contactos por nombres
        public List<Contact> Search(string[] names)
        {
            List<Contact> result = new List<Contact>();
            foreach (Contact person in this.persons)
            {
                foreach (string name in names)
                {
                    if (person.Name.Equals(name))
                    {
                        result.Add(person);
                        break;
                    }
                }
            }
            return result;
        }

        // Método para enviar un mensaje a los contactos encontrados
        public void SendMessage(string[] names, IMessageChannel channel, Message message)
        {
            List<Contact> contactsToMessage = Search(names);
            foreach (Contact contact in contactsToMessage)
            {
                channel.Send(contact, message);
            }
        }
    }
}