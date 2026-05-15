using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Manager;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Component.Abstr;
using YgoSoul.RapTech.Lib.YgoEdo.Message.Enum;

namespace YgoSoul.RapTech.Lib.YgoEdo.Message.Component;

public class BattleCmdAttackChoice : BattleCmdChoiceCard
{
    public bool DirectAttack { get; }

    public BattleCmdAttackChoice(
        PlayerBattleAction action, 
        uint index, 
        uint cardCode, 
        byte controller, 
        OCG_CardLocation location, 
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