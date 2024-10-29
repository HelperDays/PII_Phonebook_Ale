namespace Library;

public class Message
{
    public Message(string from, string to, string text)
    {
        this.From = from;
        this.To = to;
        this.Text = text;
    }

    public string Text { get; set; }

    public string From { get; }

    public string To { get; }
}