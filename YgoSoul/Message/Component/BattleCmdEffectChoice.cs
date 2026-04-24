using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class BattleCmdEffectChoice : BattleCmdChoiceCard
{
    public string Description { get; }
    public BattleCmdEffectChoice(uint index, uint cardCode, byte controller, CardLocation location, uint sequence, string description) 
        : base(index, cardCode, controller, location, sequence)
    {
        Description = description;
    }

}