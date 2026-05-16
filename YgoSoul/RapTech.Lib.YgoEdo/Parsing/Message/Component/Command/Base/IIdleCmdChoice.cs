using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

public interface IIdleCmdChoice : IIdleCommand
{
    PlayerIdleAction Action { get; }
    uint Index { get; }
}