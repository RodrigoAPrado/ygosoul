using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class AnnounceNumberParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var size = reader.ReadByte();
        var list = new List<uint>();
        for (var i = size; i > 0; i--)
        {
            list.Add((uint) reader.ReadULong64());
        }
        
        return new AnnounceNumberMessage(player, list);
    }
}