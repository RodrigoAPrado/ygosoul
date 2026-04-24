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
        reader.ReadByte();
        var hintType = (GameHintType) reader.ReadByte();
        
        return hintType switch
        {
            GameHintType.HintEvent => HandleHintEvent(reader),
            GameHintType.HintSelectMsg => new HintMessage(
                $"Player selected {CardLibrary.GetCard(BitConverter.ToUInt32(buffer, 3)).Name}"),
            _ => new UnknownMessage(buffer)
        };
    }

    private static IMessage HandleHintEvent(PacketReader reader)
    {
        var player = reader.ReadByte();
        var hintMessage = (GameHintEvent) reader.ReadUInt64();
        return new HintMessage($"Player {player}, it is {hintMessage}.");
    }
}