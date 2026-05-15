using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;

public abstract class BattleCmdChoice
{
    public PlayerBattleAction Action { get; }
    public uint Index { get; }

    protected BattleCmdChoice(PlayerBattleAction action, uint sequence)
    {
        Action = action;
        Index = sequence;
    }
}