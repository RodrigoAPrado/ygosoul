using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class BattleCmdPlayerChoice : BattleCmdChoice
{
    public PlayerActions PlayerAction { get; }
    public BattleCmdPlayerChoice(uint index, PlayerActions playerAction) : base(index)
    {
        PlayerAction = playerAction;
    }
}