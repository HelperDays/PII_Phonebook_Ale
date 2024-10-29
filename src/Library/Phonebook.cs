using System.Collections.Generic;
using System.Linq;

namespace Library
{
    public class Phonebook
    {
        private List<Contact> persons;

        public Phonebook(Contact owner)
        {
            this.Owner = owner;
            this.persons = new List<Contact>();
        }
        
        public List<Contact> Contacts => persons;
        public Contact Owner { get; set; }
        
        public void AddContact(Contact contact) 
        {
            if (contact != null && !persons.Contains(contact))
            {
                persons.Add(contact);
            }
        }

        public void RemoveContact(Contact contact)
        {
            persons.Remove(contact);
        }

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