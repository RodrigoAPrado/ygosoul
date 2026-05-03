using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Handler;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

public class BattleCmdEffectChoice : BattleCmdChoiceCard
{
    public ulong Description { get; }
    public BattleCmdEffectChoice(
        PlayerBattleAction action, 
        uint index, 
        uint cardCode, 
        byte controller, 
        CardLocation location, 
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