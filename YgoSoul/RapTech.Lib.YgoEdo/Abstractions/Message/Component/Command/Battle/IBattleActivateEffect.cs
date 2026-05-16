using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Flag;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component.Command;

public interface IBattleActivateEffect : IBattleCommand
{
    uint CardCode { get; }
    byte Controller { get; }
    Location Location { get; }
    uint Sequence { get; }
    string Description { get; }
}