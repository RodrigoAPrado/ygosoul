using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class BattleCmdOtherChoice : BattleCmdChoice
{
    public BattleCmdOtherChoice(PlayerBattleAction action, uint index) : base(action, index)
    {
    }

    public override string ToString()
    {
        return $"to {Action.ToString()}...";
    }
}