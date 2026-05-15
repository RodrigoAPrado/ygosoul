using YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

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