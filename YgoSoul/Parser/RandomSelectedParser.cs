using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class RandomSelectedParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
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
                (CardLocation) reader.ReadByte(),
                reader.ReadUInt32(), 
                (CardPosition) reader.ReadUInt32())
            );    
        }

        return new RandomSelectedMessage(player, list);
    }
}