using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SwapGraveDeckParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var extraSize = reader.ReadUInt32();
        var dataSize = reader.ReadUInt32();
        var data = new byte[dataSize];
        
        for (var i = 0; i < dataSize; i++)
        {
            data[i] = reader.ReadByte();
        }

        return new SwapGraveDeckMessage(player, extraSize, data);
    }
}