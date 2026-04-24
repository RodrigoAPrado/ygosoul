using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class BattleCmdAttackChoice : BattleCmdChoiceCard
{
    public bool DirectAttack { get; }

    public BattleCmdAttackChoice(uint index, uint cardCode, byte controller, CardLocation location, uint sequence, bool directAttack) 
        : base(index, cardCode, controller, location, sequence)
    {
        DirectAttack = directAttack;
    }
}