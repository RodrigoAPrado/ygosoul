using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component.Command;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class BattleCmdToEndPhaseChoice : BattleCmdChoice, IBattleToEndPhase
{
    public BattleCmdToEndPhaseChoice(PlayerBattleAction action, uint sequence) : base(action, sequence)
    {
    }
}