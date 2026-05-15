using YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

public class IdleCmdChoiceOther : IIdleCmdChoice
{
    public PlayerIdleAction Action { get; }
    public byte Player { get; }
    public uint Index => 0;

    public IdleCmdChoiceOther(PlayerIdleAction playerIdleAction, byte player)
    {
        Action = playerIdleAction;
        Player = player;
    }

    public override string ToString()
    {
        return $"to {Action.ToString()}...";
    }
}