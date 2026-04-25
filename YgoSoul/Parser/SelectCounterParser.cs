using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectCounterParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var counterType = reader.ReadUInt16();
        var counterAmount = reader.ReadUInt16();
        var count = reader.ReadUInt32();
        var cards = new List<CardReference>();

        for (var i = count; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation) reader.ReadByte();
            var sequence = reader.ReadByte();
            var cardCounter = reader.ReadUInt16();
            var card = new CardReference(cardCode, controller, location, sequence, 0, count -i);
            card.CounterAmount = cardCounter;
        }

        return new SelectCounterMessage(player, counterType, counterAmount, cards);
    }
}