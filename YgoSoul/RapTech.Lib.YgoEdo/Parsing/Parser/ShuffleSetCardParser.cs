using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Message;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component;
using YgoSoul.RapTech.Lib.YgoEdo.Parser.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parser;

public class ShuffleSetCardParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var location = (OCG_CardLocation) reader.ReadByte();
        var count = reader.ReadByte();
        
        var cards = new List<FullLocationReference>();
        for (var i = count; i > 0; i--)
        {
            cards .Add(new FullLocationReference(
                reader.ReadByte(), 
                (OCG_CardLocation) reader.ReadByte(), 
                reader.ReadUInt32(), 
                (OCG_CardPosition) reader.ReadUInt32())
            );
        }
        
        var xyz = new List<FullLocationReference>();
        for (var i = count; i > 0; i--)
        {
            xyz .Add(new FullLocationReference(
                reader.ReadByte(), 
                (OCG_CardLocation) reader.ReadByte(), 
                reader.ReadUInt32(), 
                (OCG_CardPosition) reader.ReadUInt32())
            );
        }
        
        return new ShuffleSetCardMessage(location, cards, xyz);
    }
}