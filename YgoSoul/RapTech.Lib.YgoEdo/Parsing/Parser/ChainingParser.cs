using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class ChainingParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        return new ChainingMessage(
            reader.ReadUInt32(), 
            reader.ReadByte(),
            (OCG_CardLocation) reader.ReadByte(),
            reader.ReadUInt32(),
            (OCG_CardPosition) reader.ReadUInt32(),
            reader.ReadByte(),
            (OCG_CardLocation) reader.ReadByte(),
            reader.ReadUInt32(),
            reader.ReadULong64(),
            reader.ReadUInt32());
    }
}