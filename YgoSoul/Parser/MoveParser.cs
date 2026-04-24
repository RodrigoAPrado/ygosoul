using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class MoveParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);

        reader.ReadByte(); // MSG_MOVE

        var cardCode = reader.ReadUInt32();

        var prevController = reader.ReadByte();
        var prevLocation = (CardLocation)reader.ReadByte();
        var prevSequence = reader.ReadUInt32();
        var prevPosition = (CardPosition) reader.ReadUInt32();

        var newController = reader.ReadByte();
        var newLocation = (CardLocation)reader.ReadByte();
        var newSequence = reader.ReadUInt32();
        var newPosition = (CardPosition) reader.ReadUInt32();

        var reason = (Reason) reader.ReadUInt32();

        return new MoveMessage(
            cardCode,
            prevController,
            prevLocation,
            prevSequence,
            prevPosition,
            reason,
            newController,
            newLocation,
            newSequence,
            newPosition
        );
    }
}