using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Handler;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

public class BattleCmdEffectChoice : BattleCmdChoiceCard
{
    public ulong Description { get; }
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
        Description = description;
    }

    public override string ToString()
    {
        return $"to activate {CardLibrary.InternalGetCard(CardCode).Name}'s effect, description={DescriptionHandler.GetDescription(Description)}";
    }
}