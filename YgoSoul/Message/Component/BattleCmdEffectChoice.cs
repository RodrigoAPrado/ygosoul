using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

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
        return $"to activate {CardLibrary.GetCard(CardCode).Name}'s effect, description={Description}";
    }
}