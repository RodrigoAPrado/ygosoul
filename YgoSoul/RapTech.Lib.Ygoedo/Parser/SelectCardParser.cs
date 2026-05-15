using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class SelectCardParser : BaseParser
{
    protected override IOcgMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var cancelable = reader.ReadByte() == 1;
        var min = reader.ReadUInt32();
        var max = reader.ReadUInt32();
        var count = reader.ReadUInt32();

        var cards = new List<CardReference>();
        
        for (var i = count; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (CardPosition)reader.ReadUInt32();
            cards.Add(new CardReference(cardCode, 
                new FullLocationReference(controller, location, sequence, position), count -i));
        }

        return new SelectCardMessage(player, cancelable, min, max, cards);
    }
}