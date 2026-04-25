using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

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