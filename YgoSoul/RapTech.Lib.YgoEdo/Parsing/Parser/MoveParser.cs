using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class MoveParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);

        reader.ReadByte(); // MSG_MOVE

        var cardCode = reader.ReadUInt32();

        var prevController = reader.ReadByte();
        var prevLocation = (OCG_CardLocation)reader.ReadByte();
        var prevSequence = reader.ReadUInt32();
        var prevPosition = (OCG_CardPosition) reader.ReadUInt32();

        var newController = reader.ReadByte();
        var newLocation = (OCG_CardLocation)reader.ReadByte();
        var newSequence = reader.ReadUInt32();
        var newPosition = (OCG_CardPosition) reader.ReadUInt32();

        var reason = (OCG_Reason) reader.ReadUInt32();

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