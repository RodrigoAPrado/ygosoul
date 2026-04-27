using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class ChangeCounterParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msg = (GameMessage) reader.ReadByte();//msg
        var counterType = reader.ReadUInt16();
        var player = reader.ReadByte();
        var location = (CardLocation) reader.ReadByte();
        var sequence = reader.ReadByte();
        var count = reader.ReadUInt16();

        switch (msg)
        {
            case GameMessage.AddCounter:
                return new AddCounterMessage(counterType, player, location, sequence, count);
            case GameMessage.RemoveCounter:
                return new RemoveCounterMessage(counterType, player, location, sequence, count);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}