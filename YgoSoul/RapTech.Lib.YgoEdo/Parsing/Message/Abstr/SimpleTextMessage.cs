namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

public abstract class SimpleTextMessage : BaseMessage
{
    private string Message { get; }

    protected SimpleTextMessage(string message)
    {
        Message = message;
    }

    public override string ToString()
    {
        return Message;
    }
}