using YgoSoul.DuelRunner;
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
            _ => new UnknownMessage(buffer)
        };
    }

    private static IMessage HandleHintEvent(PacketReader reader, byte player)
    {
        var hintMessage = (GameHintEvent) reader.ReadULong64();
        return new HintMessage($"Player {player}, it is {hintMessage}.");
    }

    private static string GetHintText(ulong hint)
    {
        return Enum.IsDefined(typeof(GameHintEvent), hint) 
            ? ((GameHintEvent)hint).ToString() 
            : CardLibrary.GetCard((uint)hint).Name;
    }
}