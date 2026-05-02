using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

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