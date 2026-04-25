using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectSumParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var mode = reader.ReadByte();
        var acc = reader.ReadUInt32();
        var min = reader.ReadUInt32();
        var max = reader.ReadUInt32();
        var mustSelectCount = reader.ReadUInt32();
        var mustSelectCards = new List<CardReference>();
        
        for (var i = mustSelectCount; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (CardPosition) reader.ReadUInt32();
            var card = new CardReference(cardCode, controller, location, sequence, position, mustSelectCount - i);
            card.Sum = reader.ReadUInt32();
            mustSelectCards.Add(card);
        }
        
        var count = reader.ReadUInt32();
        var cards = new List<CardReference>();
        
        for (var i = count; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (CardPosition) reader.ReadUInt32();
            var card = new CardReference(cardCode, controller, location, sequence, position, count - i);
            card.Sum = reader.ReadUInt32();
            cards.Add(card);
        }

        return new UnknownMessage(buffer);
    }
}