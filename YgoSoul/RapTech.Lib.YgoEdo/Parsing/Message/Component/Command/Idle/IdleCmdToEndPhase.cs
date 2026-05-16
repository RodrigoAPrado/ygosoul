using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component.Command.Idle;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class IdleCmdToEndPhase : IdleCmdChoiceOther, IIdleToEndPhase
{
    public IdleCmdToEndPhase(PlayerIdleAction playerIdleAction, uint index) : base(playerIdleAction, index)
    {
    }
}