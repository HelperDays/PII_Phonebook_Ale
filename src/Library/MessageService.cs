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

        public void SendMessage(string[] contactNames, string content, IMessageChannel channel)
        {
            List<Contact> contacts = phonebook.Search(contactNames);

            foreach (Contact contact in contacts)
            {
                if (channel is WhatsAppChannel)
                {
                    string toAddress = contact.Phone;

                    if (!string.IsNullOrEmpty(toAddress))
                    {
                        var message = new Message("WhatsApp", toAddress, content);
                        channel.Send(contact, message);
                    }
                }
            }
        }
    }
}