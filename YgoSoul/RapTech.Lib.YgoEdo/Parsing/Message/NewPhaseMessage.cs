using YgoSoul.RapTech.Lib.YgoEdo.Core.Constant;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message;

public class NewPhaseMessage : SimpleTextMessage
{
    public OCG_GamePhases GamePhase { get; }
    public NewPhaseMessage(OCG_GamePhases gamePhase) : base($"It is the {gamePhase.ToString()}")
    {
        GamePhase = gamePhase;
    }
}