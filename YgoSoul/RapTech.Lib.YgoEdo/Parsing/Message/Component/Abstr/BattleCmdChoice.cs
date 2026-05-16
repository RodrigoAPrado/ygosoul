using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

public abstract class BattleCmdChoice : IBattleCommand
{
    public PlayerBattleAction Action { get; }
    public uint Index { get; }

    protected BattleCmdChoice(PlayerBattleAction action, uint sequence)
    {
        Action = action;
        Index = sequence;
    }
}