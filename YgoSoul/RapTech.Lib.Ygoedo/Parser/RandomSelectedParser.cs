using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

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
                (CardLocation) reader.ReadByte(),
                reader.ReadUInt32(), 
                (CardPosition) reader.ReadUInt32())
            );    
        }

        return new RandomSelectedMessage(player, list);
    }
}