using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class AttackParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
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