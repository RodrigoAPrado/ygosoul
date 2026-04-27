using YgoSoul.DuelRunner;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Enum;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Message;

public class UnknownMessage : BaseMessage
{
    public override InputType Input => InputType.Unknown;

    private readonly byte[] _buffer;
    private readonly GameMessage _gameMessage;
    
    public UnknownMessage(byte[] buffer)
    {
        _buffer = buffer;
        _gameMessage = (GameMessage) buffer[0];
    }

    public override string ToString()
    {
        return $"{_gameMessage.ToString()} message. Content: {BitConverter.ToString(_buffer)}";
    }
}