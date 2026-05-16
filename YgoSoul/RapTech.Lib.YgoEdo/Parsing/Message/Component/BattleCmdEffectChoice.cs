using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Message.Component.Command;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Util;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

public class BattleCmdEffectChoice : BattleCmdChoiceCard, IBattleActivateEffect
{
    public Location Location { get; }
    public string Description { get; }
    private readonly ulong _description;
    public BattleCmdEffectChoice(
        PlayerBattleAction action, 
        uint index, 
        uint cardCode, 
        byte controller, 
        OCG_CardLocation location, 
        uint sequence, 
        ulong description) 
        : base(action, index, cardCode, controller, location, sequence)
    {
        _description = description;
        Location = _location.ToLocation();
        Description = DescriptionHandler.GetDescription(_description);
    }

    public override string ToString()
    {
        return $"to activate {CardLibrary.InternalGetCard(CardCode).Name}'s effect, description={DescriptionHandler.GetDescription(_description)}";
    }
}