using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class UnknownMessage : BaseMessage
{
    public override InputType Input => InputType.Unknown;

    private readonly byte[] _buffer;
    private readonly OCG_GameMessage _gameMessage;
    
    public UnknownMessage(byte[] buffer)
    {
        _buffer = buffer;
        _gameMessage = (OCG_GameMessage) buffer[0];
    }

    public override string ToString()
    {
        return $"{_gameMessage.ToString()} message. Content: {BitConverter.ToString(_buffer)}";
    }
}