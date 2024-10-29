namespace Library
{
    public interface IMessageChannel
    {
        // Método para enviar un mensaje a al contacto
        void Send(Contact contact, Message message);
    }
}