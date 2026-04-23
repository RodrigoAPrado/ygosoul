using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class HintParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        switch ((GameHintType) buffer[1])
        {
            case GameHintType.HintEvent:
                return HandleHintEvent(buffer);
            case GameHintType.HintSelectMsg:
                return new HintMessage($"Player selected {CardLibrary.GetCard(BitConverter.ToUInt32(buffer, 3)).Name}");
            default:
                return new UnknownMessage(buffer);
        }
    }

    private static IMessage HandleHintEvent(byte[] buffer)
    {
        switch (buffer[3])
        {
            case 27:
                return new HintMessage($"Player {buffer[2]}, it is the Draw Phase.");
            default:
                return new UnknownMessage(buffer);
        }
    }
}