using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class BattleParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var fullAttackerLocation = new FullLocationReference(
            reader.ReadByte(), 
            (CardLocation)reader.ReadByte(),
            reader.ReadUInt32(),
            (CardPosition)reader.ReadUInt32());
        var attackerAttack = reader.ReadUInt32();
        var attackerDefense = reader.ReadUInt32();
        var attackerDestroyed = reader.ReadUInt32() == 1;
        var fullDefenserLocation = new FullLocationReference(
            reader.ReadByte(), 
            (CardLocation)reader.ReadByte(),
            reader.ReadUInt32(),
            (CardPosition)reader.ReadUInt32());
        var defenderAttack = reader.ReadUInt32();
        var defenderDefense = reader.ReadUInt32();
        var defenderDestroyed = reader.ReadUInt32() == 1;

        return new BattleMessage(
            fullAttackerLocation,
            attackerAttack,
            attackerDefense,
            attackerDestroyed,
            fullDefenserLocation,
            defenderAttack,
            defenderDefense,
            defenderDestroyed);
    }
}