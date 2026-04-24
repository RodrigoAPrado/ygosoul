using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class IdleCmdChoiceOther : IIdleCmdChoice
{
    public PlayerActions PlayerAction { get; }
    public byte Player { get; }
    public uint ValueIndex { get; }

    public IdleCmdChoiceOther(PlayerActions playerAction, byte player)
    {
        PlayerAction = playerAction;
        Player = player;
        ValueIndex = 0;
    }

    public override string ToString()
    {
        return $"to {PlayerAction.ToString()}...";
    }
}