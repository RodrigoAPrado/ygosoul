using YgoSoul.Message.Abstr;

namespace YgoSoul.Message;

public class NewPhaseMessage : SimpleTextMessage
{
    public GamePhases GamePhase { get; }
    public NewPhaseMessage(GamePhases gamePhase) : base($"It is the {gamePhase.ToString()}")
    {
        GamePhase = gamePhase;
    }
}