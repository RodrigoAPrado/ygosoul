using YgoSoul.RapTech.Lib.YgoEdo.Abstractions.Duel.Enum;
using YgoSoul.RapTech.Lib.YgoEdo.Core.Flag;
using YgoSoul.RapTech.Lib.YgoEdo.Domain.Card;
using YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component.Abstr;

namespace YgoSoul.RapTech.Lib.YgoEdo.Parsing.Message.Component;

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