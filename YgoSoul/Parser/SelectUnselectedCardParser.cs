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
        var cardsToSelectSize = reader.ReadUInt32();

        var cardsToSelect = new List<CardReference>();
        for (var i = cardsToSelectSize; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (CardPosition) reader.ReadUInt32();
            cardsToSelect.Add(new CardReference(cardCode, controller, location, sequence, position, cardsToSelectSize -i));
        }
        
        var cardsToUnselectSize = reader.ReadUInt32();
        var cardsToUnselect = new List<CardReference>();
        
        for (var i = cardsToUnselectSize; i > 0; i--)
        {
            var cardCode = reader.ReadUInt32();
            var controller = reader.ReadByte();
            var location = (CardLocation)reader.ReadByte();
            var sequence = reader.ReadUInt32();
            var position = (CardPosition) reader.ReadUInt32();
            cardsToUnselect.Add(new CardReference(cardCode, controller, location, sequence, position, cardsToUnselectSize -i));
        }

        return new SelectUnselectedCardMessage(player, finishable, cancelable, min, max, cardsToSelect, cardsToUnselect);
    }
}