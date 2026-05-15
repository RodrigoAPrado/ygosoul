using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class SwapGraveDeckParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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