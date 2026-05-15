using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class RandomSelectedParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var count = reader.ReadUInt32();

        var list = new List<FullLocationReference>();
        
        for (var i = count; i > 0; i--)
        {
            list.Add(new FullLocationReference(
                reader.ReadByte(), 
                (OCG_CardLocation) reader.ReadByte(),
                reader.ReadUInt32(), 
                (OCG_CardPosition) reader.ReadUInt32())
            );    
        }

        return new RandomSelectedMessage(player, list);
    }
}