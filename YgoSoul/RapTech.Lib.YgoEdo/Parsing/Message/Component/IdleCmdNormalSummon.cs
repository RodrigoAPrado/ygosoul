using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component.Command.Idle;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class IdleCmdNormalSummon : IdleCmdChoiceCard, IIdleNormalSummon
{
    public Location Location { get; }
    public string Description { get; }
    
    public IdleCmdNormalSummon(PlayerIdleAction playerIdleAction, uint cardCode, byte player, OCG_CardLocation location, uint sequence, uint index, ulong description) : base(playerIdleAction, cardCode, player, location, sequence, index, description)
    {
        Location = _location.ToLocation();
        Description = DescriptionHandler.GetDescription(_description);
    }
}