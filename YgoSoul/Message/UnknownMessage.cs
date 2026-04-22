using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class UnknownMessage : IMessage
{
    public bool RequiresInput => true;

    private readonly byte[] _buffer;
    
    public UnknownMessage(byte[] buffer)
    {
        _buffer = buffer;
    }
    
    public byte[] GetResponse(int id)
    {
        return [0xFF];
    }

    public override string ToString()
    {
        return $"Unknown message. Content: {BitConverter.ToString(_buffer)}";
    }
}