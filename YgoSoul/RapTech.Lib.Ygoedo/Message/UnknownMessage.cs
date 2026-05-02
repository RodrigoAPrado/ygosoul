using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Enum;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

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