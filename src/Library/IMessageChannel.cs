namespace Library
{
    public interface IMessageChannel
    {
        // Método para enviar un mensaje a un contacto
        void Send(Contact contact, Message message);
    }
}