using YgoSoul.Message;
using YgoSoul.Message.Abstr;
using YgoSoul.Parser.Abstr;

namespace YgoSoul.Parser;

public class BasicParser : BaseParser
{
    protected override IMessage DoParse(byte[] buffer)
    {
        var msgType = (GameMessage)buffer[0];
        switch (msgType)
        {
            case GameMessage.NewTurn:
                return new NewTurnMessage(buffer[1]);
            case GameMessage.NewPhase:
                return new NewPhaseMessage((GamePhases) buffer[1]);
            default:
                return new UnknownMessage(buffer);
        }
    }
}