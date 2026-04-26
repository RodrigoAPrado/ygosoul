using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class ChainingParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
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