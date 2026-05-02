using YgoSoul.RapTech.Lib.Ygoedo.Flag;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component.Abstr;

public interface IIdleCmdChoice
{
    PlayerIdleAction Action { get; }
    byte Player { get; }
    uint Index { get; }
}