using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;

public interface IIdleCmdChoice
{
    PlayerIdleAction Action { get; }
    byte Player { get; }
    uint Index { get; }
}