using System.ComponentModel;
using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Handler;
using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;
using YgoSoul.Util;

namespace YgoSoul.Parser;

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
            GameHintType.HintCard => new HintMessageCard(reader.ReadUInt32()), // o resto dos 32 bits é tudo zerado
            GameHintType.HintAttrib => new HintMessageAttribute((MonsterAttributes)reader.ReadUInt32()),
            GameHintType.HintRace => new HintMessageRace((MonsterRaces)reader.ReadULong64()),
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