using YgoSoul.Flag;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

public class SelectYesNoParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        var msg = (GameMessage) reader.ReadByte();//msg

        switch (msg)
        {
            case GameMessage.SelectEffectYn:
                return GetEffectYesNo(reader);
            case GameMessage.SelectYesNo:
                return GetYesNo(reader);
            default:
                throw new ArgumentException();
        }
    }

    private IMessage GetEffectYesNo(PacketReader reader)
    {
        var player = reader.ReadByte();
        var cardCode = reader.ReadUInt32();
        var controller = reader.ReadByte();
        var location = (CardLocation)reader.ReadByte();
        var sequence = reader.ReadUInt32();
        var position = (CardPosition) reader.ReadUInt32();
        var description = reader.ReadUInt64();
        var card = new CardReference(cardCode, controller, location, sequence, position, 0);
        return new SelectYesNoMessage(player, card, description);
    }

    private IMessage GetYesNo(PacketReader reader)
    {
        var player = reader.ReadByte();
        var description = reader.ReadUInt64();
        return new SelectYesNoMessage(player, null, description);
    }
}