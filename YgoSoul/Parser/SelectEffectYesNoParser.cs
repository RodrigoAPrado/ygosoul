using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectEffectYesNoParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var player = reader.ReadByte();
        var cardCode = reader.ReadUInt32();
        var controller = reader.ReadByte();
        var location = (CardLocation)reader.ReadByte();
        var sequence = reader.ReadUInt32();
        var position = (CardPosition) reader.ReadUInt32();
        var description = reader.ReadUInt64();
        var card = new CardReference(cardCode, controller, location, sequence, position, 0);
        return new SelectEffectYesNoMessage(player, card, description);
    }
}