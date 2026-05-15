using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class AttackParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var attackerPlayer = reader.ReadByte();
        var attackerLocation = (CardLocation) reader.ReadByte();
        var attackerSequence = reader.ReadUInt32();
        var attackerPosition = (CardPosition) reader.ReadUInt32();
        var targetPlayer = reader.ReadByte();
        var targetLocation = (CardLocation) reader.ReadByte();
        var targetSequence = reader.ReadUInt32();
        var targetPosition = (CardPosition) reader.ReadUInt32();

        return new AttackMessage(
            new FullLocationReference(attackerPlayer, attackerLocation, attackerSequence, attackerPosition),
            new FullLocationReference(targetPlayer, targetLocation, targetSequence, targetPosition));
    }
}