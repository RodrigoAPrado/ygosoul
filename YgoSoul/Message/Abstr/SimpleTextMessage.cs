namespace YgoSoul.Message.Abstr;

public abstract class SimpleTextMessage : BaseMessage
{
    private readonly string _hint;
    
    protected SimpleTextMessage(string hint)
    {
        _hint = hint;
    }

    public override string ToString()
    {
        return _hint;
    }
}