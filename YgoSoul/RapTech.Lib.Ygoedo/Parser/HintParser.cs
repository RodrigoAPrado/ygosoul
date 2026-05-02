using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Parser.Abstr;
using YgoSoul.RapTech.Lib.Ygoedo.Util;

namespace YgoSoul.RapTech.Lib.Ygoedo.Parser;

public class HintParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var reader = new PacketReader(buffer);
        reader.ReadByte();//msg
        var hintType = (GameHintType) reader.ReadByte();
        var player = reader.ReadByte();
        
        return hintType switch
        {
            GameHintType.HintEvent => HandleHintEvent(reader, player),
            GameHintType.HintSelectMsg => new HintMessage($"Player {player}, {GetHintText(reader.ReadULong64())}..."),
            GameHintType.HintOpSelected => new HintMessage($"$Player {player}, choose {DescriptionHandler.GetDescription(reader.ReadULong64())}"),
            GameHintType.HintCard => new HintMessageCard(player, (uint)reader.ReadULong64()),
            GameHintType.HintAttrib => new HintMessageAttribute(player, (MonsterAttributes)reader.ReadUInt32()),
            GameHintType.HintRace => new HintMessageRace(player, (MonsterRaces)reader.ReadULong64()),
            GameHintType.HintNumber => new HintMessageNumber(player, reader.ReadULong64()),
            GameHintType.HintCode => new HintMessageCode(player, (uint)reader.ReadULong64()),
            _ => new UnknownMessage(buffer)
        };
    }

    private static IMessage HandleHintEvent(PacketReader reader, byte player)
    {
        var hintMessage = (GameStrings) reader.ReadULong64();
        return new HintMessage($"Player {player}, it is {hintMessage}.");
    }

    private static string GetHintText(ulong hint)
    {
        var rawBits = BitConverter.GetBytes(hint);
        var cardText = BitConverter.ToUInt16(rawBits, 0);
        var cardIdRaw = BitConverter.ToUInt32(rawBits, 2);
        var cardId = cardIdRaw >> 4;
        
        if(CardLibrary.HasCard(cardId))
        {
            return CardLibrary.GetCard(cardId).Strings[cardText];
        }
        
        return Enum.IsDefined(typeof(GameStrings), hint) 
            ? ((GameStrings)hint).ToString() 
            : CardLibrary.GetCard((uint)hint).Name;
    }
}