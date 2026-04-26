using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectOptionParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var count = reader.ReadByte();
        var options = new List<ulong>();
        for(int i = count; i > 0; i--)
        {
            options.Add(reader.ReadULong64());
        }

        return new SelectOptionMessage(player, options);
    }
}