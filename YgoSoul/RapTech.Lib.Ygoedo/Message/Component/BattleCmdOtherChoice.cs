using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

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