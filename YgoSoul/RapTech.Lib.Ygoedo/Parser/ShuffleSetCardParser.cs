using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class ShuffleSetCardParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var location = (CardLocation) reader.ReadByte();
        var count = reader.ReadByte();
        
        var cards = new List<FullLocationReference>();
        for (var i = count; i > 0; i--)
        {
            cards .Add(new FullLocationReference(
                reader.ReadByte(), 
                (CardLocation) reader.ReadByte(), 
                reader.ReadUInt32(), 
                (CardPosition) reader.ReadUInt32())
            );
        }
        
        var xyz = new List<FullLocationReference>();
        for (var i = count; i > 0; i--)
        {
            xyz .Add(new FullLocationReference(
                reader.ReadByte(), 
                (CardLocation) reader.ReadByte(), 
                reader.ReadUInt32(), 
                (CardPosition) reader.ReadUInt32())
            );
        }
        
        return new ShuffleSetCardMessage(location, cards, xyz);
    }
}