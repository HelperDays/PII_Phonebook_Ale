using System;
using WhatsAppApiUCU;
using Library;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            var owner = new Contact("Owner_Ale", "+59892989394","Alehernandezprincipal@gmail.com");
            var phonebook = new Phonebook(owner);
            var messageService = new MessageService(phonebook);

            var contact1 = new Contact("Ale", "+59892989394", "Alehernandezprincipal@gmail.com");
            phonebook.AddContact(contact1);

            var whatsappChannel = new WhatsAppChannel();
            messageService.SendMessage(new string[] {contact1.Name}, "Aguante el café", whatsappChannel);
            messageService.SendMessage(new []{owner.Name},"Aguante el cafe" ,whatsappChannel);
        }
    }  
}
