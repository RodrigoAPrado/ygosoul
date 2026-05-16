using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Flag;

namespace YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component.Command;

public interface IBattleAttack : IBattleCommand
{
    uint CardCode { get; }
    byte Controller { get; }
    Location Location { get; }
    uint Sequence { get; }
    bool DirectAttack { get; }
}