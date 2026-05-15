using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class AnnounceNumberParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
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