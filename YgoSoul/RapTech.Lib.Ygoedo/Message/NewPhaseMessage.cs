using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message;

public class NewPhaseMessage : SimpleTextMessage
{
    public GamePhases GamePhase { get; }
    public NewPhaseMessage(GamePhases gamePhase) : base($"It is the {gamePhase.ToString()}")
    {
        GamePhase = gamePhase;
    }
}