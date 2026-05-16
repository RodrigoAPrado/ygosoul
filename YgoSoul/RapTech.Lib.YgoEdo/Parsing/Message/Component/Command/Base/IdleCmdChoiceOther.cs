using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public abstract class IdleCmdChoiceOther : IIdleCmdChoice
{
    public PlayerIdleAction Action { get; }
    public uint Index { get; }

    public IdleCmdChoiceOther(PlayerIdleAction playerIdleAction, uint index)
    {
        Action = playerIdleAction;
        Index = index;
    }

    public override string ToString()
    {
        return $"to {Action.ToString()}...";
    }
}