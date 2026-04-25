using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class ConfirmCardParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msg = (GameMessage) reader.ReadByte();
        var player = reader.ReadByte();
        var count = reader.ReadUInt32();

        var cards = new List<CardReference>();
        
        for (var i = count; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            cards.Add(new CardReference(cardCode, controller, location, sequence, 0, count -i));
        }

        switch (msg)
        {
            case GameMessage.ConfirmDeckTop:
                return new ConfirmDeckTopMessage(player, cards);
            case GameMessage.ConfirmCards:
                return new ConfirmCardsMessage(player, cards);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}