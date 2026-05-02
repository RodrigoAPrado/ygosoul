using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

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