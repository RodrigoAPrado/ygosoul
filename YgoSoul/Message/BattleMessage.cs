using YgoSoul.Message.Abstr;
using YgoSoul.Message.Component;

namespace YgoSoul.Message;

public class BattleMessage : BaseMessage
{
    public FullLocationReference Attacker { get; }
    public uint AttackerAtk { get; }
    public uint AttackerDef { get; }
    public bool AttackerDestroyed { get; }
    public FullLocationReference Defender { get; }
    public uint DefenderAtk { get; }
    public uint DefenderDef { get; }
    public bool DefenderDestroyed { get; }

    public BattleMessage(
        FullLocationReference attacker, 
        uint attackerAtk, 
        uint attackerDef, 
        bool attackerDestroyed, 
        FullLocationReference defender, 
        uint defenderAtk, 
        uint defenderDef, 
        bool defenderDestroyed
        )
    {
        Attacker = attacker;
        AttackerAtk = attackerAtk;
        AttackerDef = attackerDef;
        AttackerDestroyed = attackerDestroyed;
        Defender = defender;
        DefenderAtk = defenderAtk;
        DefenderDef = defenderDef;
        DefenderDestroyed = defenderDestroyed;
    }

    public override string ToString()
    {
        var attackerResult = AttackerDestroyed ? "destroyed" : "survives";
        var defenderResult = DefenderDestroyed ? "destroyed" : "survives";
        return $"{Attacker} with {AttackerAtk}/{AttackerDef} vs {Defender} with {DefenderAtk}/{DefenderDef}: " +
               $"Attacker {attackerResult}, Defender {defenderResult}";
    }
}