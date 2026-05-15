using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class ChainingParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        return new ChainingMessage(
            reader.ReadUInt32(), 
            reader.ReadByte(),
            (CardLocation) reader.ReadByte(),
            reader.ReadUInt32(),
            (CardPosition) reader.ReadUInt32(),
            reader.ReadByte(),
            (CardLocation) reader.ReadByte(),
            reader.ReadUInt32(),
            reader.ReadULong64(),
            reader.ReadUInt32());
    }
}