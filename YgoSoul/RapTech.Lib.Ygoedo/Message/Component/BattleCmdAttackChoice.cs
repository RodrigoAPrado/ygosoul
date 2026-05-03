using YgoSoul.RapTech.Lib.Ygoedo.DuelRunner;
using YgoSoul.RapTech.Lib.Ygoedo.Flag;
using YgoSoul.RapTech.Lib.Ygoedo.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.Ygoedo.Message.Component;

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
        return $"to attack with {CardLibrary.InternalGetCard(CardCode).Name}...";
    }
}