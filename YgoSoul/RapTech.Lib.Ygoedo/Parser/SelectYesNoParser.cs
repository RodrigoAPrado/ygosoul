using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

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
        var description = reader.ReadULong64();
        var card = new CardReference(cardCode, controller, location, sequence, position, 0);
        return new SelectEffectYesNoMessage(player, card, description);
    }

    private IMessage GetYesNo(PacketReader reader)
    {
        var player = reader.ReadByte();
        var description = reader.ReadULong64();
        return new SelectYesNoMessage(player, description);
    }
}