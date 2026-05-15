using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class AttackParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var attackerPlayer = reader.ReadByte();
        var attackerLocation = (OCG_CardLocation) reader.ReadByte();
        var attackerSequence = reader.ReadUInt32();
        var attackerPosition = (OCG_CardPosition) reader.ReadUInt32();
        var targetPlayer = reader.ReadByte();
        var targetLocation = (OCG_CardLocation) reader.ReadByte();
        var targetSequence = reader.ReadUInt32();
        var targetPosition = (OCG_CardPosition) reader.ReadUInt32();

        return new AttackMessage(
            new FullLocationReference(attackerPlayer, attackerLocation, attackerSequence, attackerPosition),
            new FullLocationReference(targetPlayer, targetLocation, targetSequence, targetPosition));
    }
}