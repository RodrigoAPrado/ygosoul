using YgoSoul.DuelRunner;
using YgoSoul.Flag;
using YgoSoul.Message.Component.Abstr;

namespace YgoSoul.Message.Component;

public class BattleCmdAttackChoice : BattleCmdChoiceCard
{
    public bool DirectAttack { get; }

    public BattleCmdAttackChoice(
        PlayerBattleAction action, 
        uint index, 
        uint cardCode, 
        byte controller, 
        CardLocation location, 
        uint sequence, 
        bool directAttack) 
        : base(action, index, cardCode, controller, location, sequence)
    {
        DirectAttack = directAttack;
    }

    public override string ToString()
    {
        return $"to attack with {CardLibrary.GetCard(CardCode).Name}...";
    }
}