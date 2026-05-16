using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

public interface IIdleCmdChoice
{
    PlayerIdleAction Action { get; }
    byte Player { get; }
    uint Index { get; }
}