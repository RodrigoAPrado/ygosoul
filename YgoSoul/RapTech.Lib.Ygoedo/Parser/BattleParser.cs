using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

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
        var attackerDestroyed = reader.ReadByte() == 1;
        var fullDefenserLocation = new FullLocationReference(
            reader.ReadByte(), 
            (CardLocation)reader.ReadByte(),
            reader.ReadUInt32(),
            (CardPosition)reader.ReadUInt32());
        var defenderAttack = reader.ReadUInt32();
        var defenderDefense = reader.ReadUInt32();
        var defenderDestroyed = reader.ReadByte() == 1;

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