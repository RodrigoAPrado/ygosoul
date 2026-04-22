using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class IdleCmdChoiceOther : IIdleCmdChoice
{
    public PlayerActions PlayerAction { get; }
    public int ValueIndex { get; }

    public IdleCmdChoiceOther(PlayerActions playerAction)
    {
        PlayerAction = playerAction;
        ValueIndex = 0;
    }

    public override string ToString()
    {
        return $"to {PlayerAction.ToString()}...";
    }
}