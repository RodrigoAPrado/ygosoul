using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public abstract class IdleCmdChoiceOther : IIdleCmdChoice
{
    public PlayerIdleAction Action { get; }
    public byte Controller { get; }
    public uint Index => 0;

    public IdleCmdChoiceOther(PlayerIdleAction playerIdleAction, byte player)
    {
        Action = playerIdleAction;
        Controller = player;
    }

    public override string ToString()
    {
        return $"to {Action.ToString()}...";
    }
}