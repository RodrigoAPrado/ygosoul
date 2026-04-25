using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectUnselectedCardParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var finishable = reader.ReadByte() == 1;
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
            var position = (CardPosition) reader.ReadUInt32();
            cards.Add(new CardReference(cardCode, controller, location, sequence, position, count -i));
        }
        
        var unselectedCount = reader.ReadUInt32();
        var unselectedCards = new List<CardReference>();
        
        for (var i = unselectedCount; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (CardPosition) reader.ReadUInt32();
            unselectedCards.Add(new CardReference(cardCode, controller, location, sequence, position, unselectedCount -i));
        }

        return new UnselectedCardMessage(player, finishable, cancelable, min, max, cards, unselectedCards);
    }
}